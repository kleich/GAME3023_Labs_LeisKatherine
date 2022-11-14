using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dance Ability", menuName = "DanceAbilities/New Dance Ability")]
[System.Serializable]
public class DanceAbility : ScriptableObject
{
    public string Name { get { return _name; } private set { } }
    [SerializeField]
    private string _name;
    public string Description { get { return _description; } private set { } }
    [SerializeField] private string _description;
    public float Power { get { return _power; } private set { } }
    [SerializeField] private float _power;
    public float Cost { get { return _cost; } private set { } }
    [SerializeField] private float _cost;
}
