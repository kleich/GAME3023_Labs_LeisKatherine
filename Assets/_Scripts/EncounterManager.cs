using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    private PlayerMovement _playerReference;
    public Camera _encounterCamera;
    private Camera _mainSceneCamera;
    private void Start()
    {
        foreach (Camera camera in FindObjectsOfType<Camera>())
        {
            if(camera.name != _encounterCamera.name)
                _mainSceneCamera = camera;
        }
        ToggleCamera(_mainSceneCamera, false);
        _playerReference = FindObjectOfType<PlayerMovement>();
    }

    public void CloseEncounter()
    {
        ToggleCamera(_mainSceneCamera, true);
        ToggleCamera(_encounterCamera, false);
        _playerReference.InEncounter = false;
    }

    private void ToggleCamera(Camera camera, bool is_active)
    {
        camera.enabled = is_active;
        camera.gameObject.SetActive(is_active);
    }
}
