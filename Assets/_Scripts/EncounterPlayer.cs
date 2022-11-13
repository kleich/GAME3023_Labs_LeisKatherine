using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterPlayer : MonoBehaviour
{
    public bool CanPerformDance { get { return _canPerformDance; } private set { } }
    private bool _canPerformDance;
    public int DanceDelaySeconds { get { return _danceDelaySeconds; } private set { } }
    private int _danceDelaySeconds;

    private Animator _animator;

    public delegate void PerformBattleAction();
    public static event PerformBattleAction OnPerformDance;
    private void OnEnable()
    {
        OnPerformDance += PerformBattleActionSequence;
        EncounterEventManager.OnDanceOnePressed += DanceOne;
        EncounterEventManager.OnDanceTwoPressed += DanceTwo;
        EncounterEventManager.OnDanceThreePressed += DanceThree;
        EncounterEventManager.OnDanceFourPressed += DanceFour;
    }
    private void OnDisable()
    {
        OnPerformDance -= PerformBattleActionSequence;
        EncounterEventManager.OnDanceOnePressed -= DanceOne;
        EncounterEventManager.OnDanceTwoPressed -= DanceTwo;
        EncounterEventManager.OnDanceThreePressed -= DanceThree;
        EncounterEventManager.OnDanceFourPressed -= DanceFour;
    }
    private void Start()
    {
        _danceDelaySeconds = 2;
        _canPerformDance = true;
        _animator = GetComponent<Animator>();

    }
    private void PerformBattleActionSequence()
    {
        if(_canPerformDance)
        {
            _canPerformDance = false;
            StartCoroutine(DanceDelayTimer(_danceDelaySeconds));
            
        }
    }
    IEnumerator DanceDelayTimer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _canPerformDance = true;
        Debug.Log("Can perform next action now!");
    }
    private void DanceOne()
    {
        if(_canPerformDance)
        {
            Debug.Log("Performing Dance #1");
            OnPerformDance();
            _animator.SetTrigger("DanceOneTrigger");
        }
    }
    private void DanceTwo()
    {
        if (_canPerformDance)
        {
            Debug.Log("Performing Dance #2");
            OnPerformDance();
            _animator.SetTrigger("DanceTwoTrigger");
        }
    }
    private void DanceThree()
    {
        if (_canPerformDance)
        {
            Debug.Log("Performing Dance #3");
            OnPerformDance();
            _animator.SetTrigger("DanceThreeTrigger");
        }
    }
    private void DanceFour()
    {
        if (_canPerformDance)
        {
            Debug.Log("Performing Dance #4");
            OnPerformDance();
            _animator.SetTrigger("DanceFourTrigger");
        }
    }
}
