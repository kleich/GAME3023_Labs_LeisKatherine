using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy
{
    public string Name { get { return _name; } private set { } }
    private string _name;

    public Color Hue { get { return _hue; } private set { } }
    private Color _hue;
    public string Description { get { return _description; } private set { } }
    private string _description;
    public float Speed { get { return _speed; } private set { } }
    private float _speed;
    public float MaxEnergy { get { return _energy; } private set { } }
    private float _energy;
    public List<DanceAbility> DanceMoves { get { return _danceMoves.ToList(); } private set { } }
    [SerializeField] private List<DanceAbility> _danceMoves = new List<DanceAbility>();

    public Enemy(string name, Color hue, string description, float speed, float energy, List<DanceAbility> dances)
    {
        _name = name;
        _hue = hue;
        _description = description;
        _speed = speed;
        _energy = energy;

        var count = (dances.Count < 4) ? dances.Count : 4;

        for (int i = 0; i < count; i++)
        {
            if (dances[i] == null)
                break;
            _danceMoves.Add(dances[i]);
        }
    }
}
