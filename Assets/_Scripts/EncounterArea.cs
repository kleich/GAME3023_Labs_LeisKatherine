using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterArea : MonoBehaviour
{
    private SceneControl _sceneControl;
    public Object _encounterScene;
    private PlayerMovement _playerReference;
    private bool _encounterStarted => _playerReference.InEncounter;
    private float _encounterCheckInterval = 2f;

    [SerializeField]
    private float _encounterChancePercentage;
    private void Start()
    {
        _sceneControl = FindObjectOfType<SceneControl>();
        _playerReference = FindObjectOfType<PlayerMovement>();
    }
    void Update()
    {
        if (_playerReference.InEncounterArea && _playerReference.IsMoving)
        {
            if(CalculateEncounterChance() && !_encounterStarted)
            {
                StartEncounter();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            _playerReference.InEncounterArea = true;
            Debug.Log("Player entered Encounter Area! Get ready for a fight (maybe)!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            _playerReference.InEncounterArea = false;
            Debug.Log("Player exited Encounter Area! Safe for now...");
        }
    }

    private bool CalculateEncounterChance()
    {
        if(_playerReference.EncounterAreaMovementTimer > _encounterCheckInterval)
        {
            Debug.Log("Encounter imminent!");
            _playerReference.EncounterAreaMovementTimer = 0;

            float random_number = Random.Range(0f, 100f);
            if (random_number <= _encounterChancePercentage)
            {
                Debug.Log("*** Encounter started! ***");
                return true;
            }
        }

        return false;
    }

    private void StartEncounter()
    {
        _playerReference.InEncounter = true;
        _sceneControl.LoadSceneAdditive(_encounterScene);
    }
}
