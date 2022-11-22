using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies/New Enemy")]
[System.Serializable]

public class EnemyData : ScriptableObject
{
    public string Name { get { return _name; } private set { } }
    [SerializeField] private string _name;

    public Color Hue { get { return _hue; } private set { } }
    [SerializeField] private Color _hue;
    public string Description { get { return _description; } private set { } }
    [SerializeField] private string _description;
    public float Speed { get { return _speed; } private set { } }
    [SerializeField] private float _speed;
    public float MaxEnergy { get { return _energy; } private set { } }
    [SerializeField] private float _energy;

    public List<DanceAbility> DanceMoves 
    { get 
        { 
            if(_danceMoves.Length > 4)
            {
                Array.Resize(ref _danceMoves, 4);
            }
            return _danceMoves.ToList(); 
        } 
        private set { } 
    }
    [SerializeField] private DanceAbility[] _danceMoves = new DanceAbility[4];
}
