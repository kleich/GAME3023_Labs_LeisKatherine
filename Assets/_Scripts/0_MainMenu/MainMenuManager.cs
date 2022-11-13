using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject _continueButton;

    void Start()
    {
        _continueButton.GetComponent<Button>().interactable = GameDataManager.DoesCharacterDataExist();
        DanceAbilityManager.LoadDancesFromResources();
    }
}
