using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Name { get { return _name; } private set { } }
    private string _name;
    public float Speed { get { return _speed; } private set { } }
    private float _speed;
    public float MaxEnergy { get { return _maxEnergy; } private set { } }
    private float _maxEnergy;
    public static Player Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _maxEnergy = 20;
    }

}
