using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _moveSpeed = 2f;
    private Vector2 _moveInput;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        transform.position += new Vector3(_moveInput.x, _moveInput.y) * _moveSpeed * Time.deltaTime;
    }
}
