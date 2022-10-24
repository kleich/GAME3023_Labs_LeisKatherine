using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButtonVisibility : MonoBehaviour
{
    public GameObject _continueButton;

    void Start()
    {
        _continueButton.GetComponent<Button>().interactable = GameDataManager.DoesCharacterDataExist();
    }
}
