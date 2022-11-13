using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterPlayer : MonoBehaviour
{
    public bool CanPerformDance { get { return _canPerformDance; } private set { } }
    private bool _canPerformDance;
    public int DanceDelaySeconds { get { return _danceDelaySeconds; } private set { } }
    private int _danceDelaySeconds;

    private List<DanceAbility> _knownDanceAbilities = DanceAbilityManager.PlayerDanceAbilities;
    public DanceAbility[] SlottedDanceAbilities { get { return _slottedDanceAbilities; } private set { } }
    [SerializeField] private DanceAbility[] _slottedDanceAbilities = new DanceAbility[4];

    private Animator _animator;

    private void OnEnable()
    {
        EncounterEventManager.OnDanceOnePressed += DanceOne;
        EncounterEventManager.OnDanceTwoPressed += DanceTwo;
        EncounterEventManager.OnDanceThreePressed += DanceThree;
        EncounterEventManager.OnDanceFourPressed += DanceFour;
        EncounterEventManager.OnDanceSequence += DanceSequence;
    }
    private void OnDisable()
    {
        EncounterEventManager.OnDanceOnePressed -= DanceOne;
        EncounterEventManager.OnDanceTwoPressed -= DanceTwo;
        EncounterEventManager.OnDanceThreePressed -= DanceThree;
        EncounterEventManager.OnDanceFourPressed -= DanceFour;
        EncounterEventManager.OnDanceSequence -= DanceSequence;
    }
    private void Start()
    {
        _danceDelaySeconds = 2;
        _canPerformDance = true;
        _animator = GetComponent<Animator>();

    }
    public void SetCanDance(bool b)
    {
        _canPerformDance = b;
    }
    private void DanceSequence()
    {
        if(_canPerformDance)
        {
            _canPerformDance = false;
        }
    }
    private void DanceOne()
    {
        if(_canPerformDance && (_slottedDanceAbilities[0] != null))
        {
            Debug.Log("Performing " + _slottedDanceAbilities[0].Name);
            _animator.SetTrigger(_slottedDanceAbilities[0].Name + "Trigger");
        }
    }
    private void DanceTwo()
    {
        if (_canPerformDance && (_slottedDanceAbilities[1] != null))
        {
            Debug.Log("Performing " + _slottedDanceAbilities[1].Name);
            _animator.SetTrigger(_slottedDanceAbilities[1].Name + "Trigger");
        }
    }
    private void DanceThree()
    {
        if (_canPerformDance && (_slottedDanceAbilities[2] != null))
        {
            Debug.Log("Performing " + _slottedDanceAbilities[2].Name);
            _animator.SetTrigger(_slottedDanceAbilities[2].Name + "Trigger");
        }
    }
    private void DanceFour()
    {
        if (_canPerformDance && (_slottedDanceAbilities[3] != null))
        {
            Debug.Log("Performing " + _slottedDanceAbilities[3].Name);
            _animator.SetTrigger(_slottedDanceAbilities[3].Name + "Trigger");
        }
    }
}
