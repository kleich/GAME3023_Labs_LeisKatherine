using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        _danceButtonsPanel.SetActive(false);
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
