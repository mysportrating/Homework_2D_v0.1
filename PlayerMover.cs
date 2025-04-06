using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";

    [SerializeField] private float _playerSpeed = 2.0f;
    [SerializeField] private float _boostedSpeed = 1000.0f;

    private Rigidbody2D _playerRb;
    private float _directionX;
    private float _directionY;
    private bool _isBoosted;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _directionX = Input.GetAxis(HORIZONTAL_AXIS);
        _directionY = Input.GetAxis(VERTICAL_AXIS);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isBoosted = true;
        }
    }

    private void FixedUpdate()
    {
        _playerRb.velocity = new Vector2(_directionX * _playerSpeed, _directionY * _playerSpeed);

        if(_isBoosted)
        {
            _playerRb.AddForce(_playerRb.velocity * _boostedSpeed);
            _isBoosted = false;
        }
    }
}
