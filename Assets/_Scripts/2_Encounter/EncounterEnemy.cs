using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EncounterEnemy : MonoBehaviour
{
    Animator _animator;
    public float DanceDelaySeconds { get { return _danceDelaySeconds; } private set { } }
    private float _danceDelaySeconds;
    
    // Serialized for debug purposes
    [SerializeField] List<DanceAbility> _knownDanceAbilities = new List<DanceAbility>();
    [SerializeField] DanceAbility[] _slottedDanceAbilities = new DanceAbility[4];
    private void OnEnable()
    {
        EncounterEventManager.OnEnemyDanceTurn += PerformDance;
    }
    private void OnDisable()
    {
        EncounterEventManager.OnEnemyDanceTurn -= PerformDance;
    }
    private void Start()
    {
        _danceDelaySeconds = 2f;
        _animator = GetComponent<Animator>();
        ConfigureDanceMoves();
    }
    private void ConfigureDanceMoves()
    {
        _knownDanceAbilities = DanceAbilityManager.EnemyDanceAbilities;

        for (int i = 0; i < _slottedDanceAbilities.Length; i++)
        {
            var index = Random.Range(0, _knownDanceAbilities.Count);
            _slottedDanceAbilities[i] = _knownDanceAbilities[index];
        }
    }
    private void PerformDance()
    {
        // Do dance move AI here
        var index = Random.Range(0, _slottedDanceAbilities.Length);
        _animator.SetTrigger(_slottedDanceAbilities[index].Name + "Trigger");
        Debug.Log("Enemy performing " + _slottedDanceAbilities[index].Name);
    }
}
