using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EncounterManager : MonoBehaviour
{
    private PlayerMovement _playerMovementReference;
    private EncounterPlayer _encounterPlayerReference;
    public Camera _encounterCamera;
    private Camera _mainSceneCamera;
    [SerializeField] private Button[] _abilityButtons = new Button[4];
    private void Start()
    {
        foreach (Camera camera in FindObjectsOfType<Camera>())
        {
            if(camera.name != _encounterCamera.name)
                _mainSceneCamera = camera;
        }
        ToggleCamera(_mainSceneCamera, false);
        _playerMovementReference = FindObjectOfType<PlayerMovement>();
        _encounterPlayerReference = FindObjectOfType<EncounterPlayer>();
        ConfigureAbilityButtons();
    }
    private void OnEnable()
    {
        var eventsystems = FindObjectsOfType<EventSystem>();
        eventsystems[0].gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        var eventsystems = FindObjectsOfType<EventSystem>();
        eventsystems[0].gameObject.SetActive(true);
    }

    public void CloseEncounter()
    {
        ToggleCamera(_mainSceneCamera, true);
        ToggleCamera(_encounterCamera, false);
        _playerMovementReference.InEncounter = false;
    }

    private void ToggleCamera(Camera camera, bool is_active)
    {
        camera.enabled = is_active;
        camera.gameObject.SetActive(is_active);
    }

    private void ConfigureAbilityButtons()
    {
        for (int i = 0; i < _abilityButtons.Length; i++)
        {
            if(_encounterPlayerReference.SlottedDanceAbilities[i] != null)
            {
                _abilityButtons[i].GetComponentInChildren<TMP_Text>().text = _encounterPlayerReference.SlottedDanceAbilities[i].Name;
            }
            else
            {
                _abilityButtons[i].interactable = false;
                _abilityButtons[i].GetComponentInChildren<TMP_Text>().text = " ";
            }
        }
    }
}
