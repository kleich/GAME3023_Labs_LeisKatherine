using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterPlayer : MonoBehaviour
{
    private Animator _animator;
    private void OnEnable()
    {
        EncounterEventManager.OnDanceOnePressed += DanceOne;
        EncounterEventManager.OnDanceTwoPressed += DanceTwo;
        EncounterEventManager.OnDanceThreePressed += DanceThree;
        EncounterEventManager.OnDanceFourPressed += DanceFour;
    }
    private void OnDisable()
    {
        EncounterEventManager.OnDanceOnePressed -= DanceOne;
        EncounterEventManager.OnDanceTwoPressed -= DanceTwo;
        EncounterEventManager.OnDanceThreePressed -= DanceThree;
        EncounterEventManager.OnDanceFourPressed -= DanceFour;
    }
    private void Start()
    {
        _animator = GetComponent<Animator>();   
    }
    private void DanceOne()
    {
        _animator.SetTrigger("DanceOneTrigger");
    }
    private void DanceTwo()
    {
        _animator.SetTrigger("DanceTwoTrigger");
    }
    private void DanceThree()
    {
        _animator.SetTrigger("DanceThreeTrigger");
    }
    private void DanceFour()
    {
        _animator.SetTrigger("DanceFourTrigger");
    }
}
