using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EncounterEventManager : MonoBehaviour
{
    public delegate void DanceOnePressed();
    public static event DanceOnePressed OnDanceOnePressed;
    public delegate void DanceTwoPressed();
    public static event DanceTwoPressed OnDanceTwoPressed;
    public delegate void DanceThreePressed();
    public static event DanceThreePressed OnDanceThreePressed;
    public delegate void DanceFourPressed();
    public static event DanceFourPressed OnDanceFourPressed;

    public GameObject _danceButtonsPanel;
    public GameObject _encounterButtonsPanel;
    public TMP_Text _encounterText;
    private EncounterPlayer _playerReference;
    private void OnEnable()
    {
        _playerReference = FindObjectOfType<EncounterPlayer>();
        EncounterPlayer.OnPerformDance += PerformingDance;
    }
    private void OnDisable()
    {
        EncounterPlayer.OnPerformDance -= PerformingDance;
    }
    private void Start()
    {
        _danceButtonsPanel.SetActive(false);
    }
    public void PerformingDance()
    {
        if (_playerReference.CanPerformDance)
        {
            _encounterText.text = "Performing dance!";
            _danceButtonsPanel.SetActive(false);
            _encounterButtonsPanel.SetActive(false);
            StartCoroutine(DanceDelay(_playerReference.DanceDelaySeconds));
        }
    }

    private IEnumerator DanceDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _danceButtonsPanel.SetActive(true);
        _encounterButtonsPanel.SetActive(true);
        _encounterText.text = "Select a dance to perform!";
    }
    public void ReadyDances()
    {
        _danceButtonsPanel.SetActive(true);
    }
    public void CancelDance()
    {
        _danceButtonsPanel.SetActive(false);
    }

    public void DanceOneButtonPressed()
    {
        OnDanceOnePressed();
    }
    public void DanceTwoButtonPressed()
    {
        OnDanceTwoPressed();
    }
    public void DanceThreeButtonPressed()
    {
        OnDanceThreePressed();
    }
    public void DanceFourButtonPressed()
    {
        OnDanceFourPressed();
    }
}
