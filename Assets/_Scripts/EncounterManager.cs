using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    private PlayerMovement _playerReference;
    private void Start()
    {
        _playerReference = FindObjectOfType<PlayerMovement>();
    }

    public void CloseEncounter()
    {
        _playerReference.InEncounter = false;
    }
}
