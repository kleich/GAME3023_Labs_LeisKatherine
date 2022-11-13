using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterEnemy : MonoBehaviour
{
    Animator _animator;
    public float DanceDelaySeconds { get { return _danceDelaySeconds; } private set { } }
    private float _danceDelaySeconds;
    
    List<DanceAbility> _knownDanceAbilities = DanceAbilityManager.EnemyDanceAbilities;
    List<DanceAbility> _slottedDanceAbilities = new List<DanceAbility>();
    private void OnEnable()
    {
        EncounterEventManager.OnEnemyDanceTurn += Dance;
    }
    private void OnDisable()
    {
        EncounterEventManager.OnEnemyDanceTurn -= Dance;
    }
    private void Start()
    {
        _danceDelaySeconds = 2f;
        _animator = GetComponent<Animator>();
    }

    private void Dance()
    {
        _animator.SetTrigger("DanceOne");
    }
}
