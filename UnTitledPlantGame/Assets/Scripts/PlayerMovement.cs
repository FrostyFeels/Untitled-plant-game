using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    [SerializeField] private Rigidbody2D _rb;
    private bool _isSprinting;
    [SerializeField] private float _sprintMultiplier;
    private Vector2 _moveDirection;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _isSprinting = true;
            Sprint();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _isSprinting = false;
            Sprint();
        }
    }
     
    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        _moveDirection = new Vector2(moveX, moveY);
    }

    void Move()
    {
        _rb.velocity = new Vector2(_moveDirection.x * MoveSpeed, _moveDirection.y * MoveSpeed);
    }

    private void Sprint()
    {
        if (_isSprinting) 
        {
            MoveSpeed *= _sprintMultiplier;
        }
        if (!_isSprinting)
        {
            MoveSpeed /= _sprintMultiplier;
        }
    }
}
