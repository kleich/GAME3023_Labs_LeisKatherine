using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public class EncounterEnemy : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    [SerializeField] private Enemy _enemyInScene;
    private float _currentEnergy;
    public float DanceDelaySeconds { get { return _danceDelaySeconds; } private set { } }
    private float _danceDelaySeconds;
    
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
        _spriteRenderer = GetComponent<SpriteRenderer>();
        ConfigureEnemy();
    }

    private void ConfigureEnemy()
    {
        _enemyInScene = EnemyTypeManager.PossibleEnemies.First();
        _spriteRenderer.color = _enemyInScene.Hue;
        _currentEnergy = _enemyInScene.MaxEnergy;
    }
    private void PerformDance()
    {
        /* AI:
         * - if full energy, choose highest value move
         * - if energy < 1/2 - choose lowest value move
         * - if only 1 move to use, use that move
         * 
         */
        if(_currentEnergy > 0)
        {
            DanceAbility dance_to_use = _enemyInScene.DanceMoves[0]; // Enemies MUST have at least 1 move!!

            Debug.Assert(dance_to_use != null);

            if (_enemyInScene.DanceMoves.Count == 1) // Only 1 dance move, use it.
            {
                _animator.SetTrigger(dance_to_use.Name + "Trigger");
                Debug.Log("Enemy only has 1 move! Using it...");
                Debug.Log("Enemy performing " + dance_to_use.Name);
                return;
            }

            // energy is 50% or higher, use the highest cost move we can
            if (_currentEnergy > (_enemyInScene.MaxEnergy * 0.5f))
            {
                Debug.Log("Big dance move incoming!");
                foreach (var dance in _enemyInScene.DanceMoves)
                {
                    if (dance.Cost > dance_to_use.Cost)
                    {
                        dance_to_use = dance;
                    }
                }
            }

            // energy is less than 50%, start conserving it!
            else if (_currentEnergy < (_enemyInScene.MaxEnergy * 0.5f))
            {
                Debug.Log("Energy saving mode, activate!");
                foreach (var dance in _enemyInScene.DanceMoves)
                {
                    if (dance.Cost < dance_to_use.Cost)
                    {
                        dance_to_use = dance;
                    }
                }
            }
            if(_currentEnergy >= dance_to_use.Cost)
            {
                _animator.SetTrigger(dance_to_use.Name + "Trigger");
                Debug.Log("Enemy performing " + dance_to_use.Name);
                _currentEnergy -= dance_to_use.Cost;
            }
            else
            {
                Debug.Log("Enemy has no energy left!");
            }
        }
    }
}
