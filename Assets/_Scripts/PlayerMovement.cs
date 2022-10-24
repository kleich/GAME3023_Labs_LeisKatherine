using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _moveSpeed = 2f;
    private Vector2 _moveInput;
    private Rigidbody2D _rb;
    public bool InEncounterArea { get { return _inEncounterArea; } set { _inEncounterArea = value; } }
    private bool _inEncounterArea = false;
    public bool InEncounter { get { return _inEncounter; } set { _inEncounter = value; } }
    private bool _inEncounter = false;
    public bool IsMoving {  get { return _isMoving; } set { _isMoving = value; } }
    private bool _isMoving = false;
    public float EncounterAreaMovementTimer { get { return _encounterAreaMovementTimer; } set { _encounterAreaMovementTimer = value; } }
    private float _encounterAreaMovementTimer = 0f;
    private Vector2 _startPosition = new Vector2(4.3f, -1.5f);

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        SetPlayerStartPosition();
    }


    private void FixedUpdate()
    {
        if(!_inEncounter)
            Move();
    }

    private void Move()
    {
        _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        transform.position += new Vector3(_moveInput.x, _moveInput.y) * _moveSpeed * Time.deltaTime;

        if (_inEncounterArea)
        {
            if(_moveInput.Abs().x > 0 || _moveInput.Abs().y > 0)
            {
                _encounterAreaMovementTimer += Time.deltaTime;
                _isMoving = true;
            }
            else
                _isMoving = false;
        }
    }
    private void SetPlayerStartPosition()
    {
        if (GameDataManager.WasDataLoaded)
        {
            transform.position = GameDataManager.PlayerPosition;
        }
        else
        {
            transform.position = _startPosition;
        }
    }

}

