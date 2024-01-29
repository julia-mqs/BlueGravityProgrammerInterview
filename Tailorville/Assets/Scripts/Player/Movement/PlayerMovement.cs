using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject _rogueGO;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;

    [Header("Configs")]
    [SerializeField] private float _playerSpeed = 5f;
    [SerializeField] private float _screenBorder = 25f;

    private bool _isMoving;
    private Camera _camera;
    private Vector2 _playerMovement;
    private Vector2 _screenPosition;
    private bool _flippedLeft = false;

    #endregion

    #region Messages

    private void Awake()
    {
        _camera = Camera.main;

        Nullchecks();
    }

    private void FixedUpdate()
    {
        if (_rigidbody == null)
            return;

        if (MenusManager.setGameMode != GameMode.Playing)
            _playerMovement = Vector2.zero;

        _rigidbody.velocity = _playerMovement * _playerSpeed;

        FlipSprite();
        SetAnimation();
        PreventOffScreen();
    }

    #endregion

    #region Methods

    private void OnMove(InputValue inputValue)
    {
        if (MenusManager.setGameMode != GameMode.Playing)
        {
            _playerMovement = Vector2.zero;
            return;
        }

        _playerMovement = inputValue.Get<Vector2>();
    }

    private void PreventOffScreen()
    {
        _screenPosition = _camera.WorldToScreenPoint(transform.position);

        if ((_screenPosition.x < _screenBorder && _rigidbody.velocity.x < 0) || (_screenPosition.x > _camera.pixelWidth - _screenBorder && _rigidbody.velocity.x > 0))
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }

        if ((_screenPosition.y < _screenBorder && _rigidbody.velocity.y < 0) || (_screenPosition.y > _camera.pixelHeight - _screenBorder && _rigidbody.velocity.y > 0))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        }
    }

    private void SetAnimation()
    {
        if (_animator == null)
            return;

        _isMoving = _playerMovement != Vector2.zero;
        _animator.SetBool("isMoving", _isMoving);
    }

    private void FlipSprite()
    {
        if (_playerMovement.x > 0 && _flippedLeft)
            Flip();
        
        if (_playerMovement.x < 0 && !_flippedLeft)
            Flip();
    }

    private void Flip()
    {
        if (_rogueGO == null)
            return;

        Vector3 currentScale = _rogueGO.transform.localScale;
        currentScale.x *= -1;
        _rogueGO.transform.localScale = currentScale;

        _flippedLeft = !_flippedLeft;
    }

    private void Nullchecks()
    {
        if (_rigidbody == null)
            Debug.Log("Rigidbody variable is empty in: " + this.gameObject);

        if (_animator == null)
            Debug.Log("Animator variable is empty in: " + this.gameObject);

        if (_rogueGO == null)
            Debug.Log("Rogue GO variable is empty in: " + this.gameObject);
    }

    #endregion
}