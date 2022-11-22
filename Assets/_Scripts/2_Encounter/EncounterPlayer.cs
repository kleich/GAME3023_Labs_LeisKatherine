using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EncounterPlayer : MonoBehaviour
{
    public bool CanPerformDance { get { return _canPerformDance; } private set { } }
    private bool _canPerformDance;
    public int DanceDelaySeconds { get { return _danceDelaySeconds; } private set { } }
    private int _danceDelaySeconds;

    private List<DanceAbility> _knownDanceAbilities = DanceAbilityManager.PlayerDanceAbilities;
    public DanceAbility[] SlottedDanceAbilities { get { return _slottedDanceAbilities; } private set { } }
    [SerializeField] private DanceAbility[] _slottedDanceAbilities = new DanceAbility[4];
    [SerializeField] private TMP_Text _encounterText;
    [SerializeField] private Slider _energyBar;
    private float _currentEnergy;

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
        _currentEnergy = Player.Instance.MaxEnergy;
        _energyBar.maxValue = _currentEnergy;
        _energyBar.value = _currentEnergy;
    }
    private void SetEnergyAfterUsingDanceMove(float value)
    {
        _currentEnergy -= value;
        var energy = _currentEnergy / 1;
        _energyBar.value = energy;
    }
    public void SetCanDance(bool b)
    {
        _canPerformDance = b;
    }
    private void DanceSequence()
    {
        if(_currentEnergy > 0)
        {
            _canPerformDance = false;
        }

        if(_canPerformDance)
        {
            _canPerformDance = false;
        }
    }
    private void DanceOne()
    {
        if(_canPerformDance && (_slottedDanceAbilities[0] != null))
        {
            SetEnergyAfterUsingDanceMove(_slottedDanceAbilities[0].Cost);
            _encounterText.text = $"Performing {_slottedDanceAbilities[0].Name}! Nice moves!";
            _animator.SetTrigger(_slottedDanceAbilities[0].Name + "Trigger");
        }
    }
    private void DanceTwo()
    {
        if (_canPerformDance && (_slottedDanceAbilities[1] != null))
        {
            SetEnergyAfterUsingDanceMove(_slottedDanceAbilities[1].Cost);
            _encounterText.text = $"Performing {_slottedDanceAbilities[1].Name}! Nice moves!";
            _animator.SetTrigger(_slottedDanceAbilities[1].Name + "Trigger");
        }
    }
    private void DanceThree()
    {
        if (_canPerformDance && (_slottedDanceAbilities[2] != null))
        {
            SetEnergyAfterUsingDanceMove(_slottedDanceAbilities[2].Cost);
            _encounterText.text = $"Performing {_slottedDanceAbilities[2].Name}! Nice moves!";
            _animator.SetTrigger(_slottedDanceAbilities[2].Name + "Trigger");
        }
    }
    private void DanceFour()
    {
        if (_canPerformDance && (_slottedDanceAbilities[3] != null))
        {
            SetEnergyAfterUsingDanceMove(_slottedDanceAbilities[3].Cost);
            _encounterText.text = $"Performing {_slottedDanceAbilities[3].Name}! Nice moves!";
            _animator.SetTrigger(_slottedDanceAbilities[3].Name + "Trigger");
        }
    }
}
