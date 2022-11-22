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

    public delegate void DanceSequence();
    public static event DanceSequence OnDanceSequence;

    public delegate void EnemyDanceTurn();
    public static event EnemyDanceTurn OnEnemyDanceTurn;




    public GameObject _danceButtonsPanel;
    public GameObject _encounterButtonsPanel;
    public TMP_Text _encounterText;
    private EncounterPlayer _playerReference;
    private EncounterEnemy _enemyReference;

    private void OnEnable()
    {
        _playerReference = FindObjectOfType<EncounterPlayer>();
        _enemyReference = FindObjectOfType<EncounterEnemy>();
        OnDanceSequence += StartDanceSequence;
    }
    private void OnDisable()
    {
        OnDanceSequence -= StartDanceSequence;
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
            StartCoroutine(PlayerDanceDelay(_playerReference.DanceDelaySeconds));
        }
    }

    private void StartDanceSequence()
    {
        _danceButtonsPanel.SetActive(false);
        _encounterButtonsPanel.SetActive(false);
        _encounterText.text = "Nice moves, alien!";
        StartCoroutine(PlayerDanceDelay(_playerReference.DanceDelaySeconds));
    }

    private IEnumerator PlayerDanceDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _encounterText.text = "Enemy's turn!";
        StartCoroutine(EnemyDanceDelay(_enemyReference.DanceDelaySeconds));
    }

    private IEnumerator EnemyDanceDelay(float seconds)
    {
        OnEnemyDanceTurn();
        yield return new WaitForSeconds(seconds);
        _encounterButtonsPanel.SetActive(true);
        _encounterText.text = "Your turn!";
        _playerReference.SetCanDance(true);
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
        OnDanceSequence();
    }
    public void DanceTwoButtonPressed()
    {
        OnDanceTwoPressed();
        OnDanceSequence();
    }
    public void DanceThreeButtonPressed()
    {
        OnDanceThreePressed();
        OnDanceSequence();
    }
    public void DanceFourButtonPressed()
    {
        OnDanceFourPressed();
        OnDanceSequence();
    }
}
