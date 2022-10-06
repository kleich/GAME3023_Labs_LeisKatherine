using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class EncounterArea : MonoBehaviour
{
    public Object EncounterScene;
    private PlayerMovement _playerReference;
    public bool EncounterStarted { get { return _encounterStarted; } private set { } }
    [SerializeField] private bool _encounterStarted;

    [SerializeField] private bool _encounterPossible;
    [SerializeField] private bool _playerInEncounterArea => _playerReference.InEncounterArea;

    [SerializeField]
    private float _encounterChancePercentage;

    private void Start()
    {
        _playerReference = FindObjectOfType<PlayerMovement>();
    }
    void Update()
    {
        if (_playerInEncounterArea)
        {
            CheckEncounterPossibleFromPlayer();
        }

        if (_encounterPossible)
        {
            _encounterStarted = CalculateEncounterChance();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            _playerReference.InEncounterArea = true;
            Debug.Log("Player entered Encounter Area! Get ready for a fight (maybe)!");
            _encounterPossible = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            _playerReference.InEncounterArea = false;
            Debug.Log("Player exited Encounter Area! Safe for now...");
            _encounterPossible = false;
        }
    }

    // This is so that encounters only trigger when the player is moving.
    private void CheckEncounterPossibleFromPlayer()
    {
        if (_playerReference.EncounterAreaMovementTimer >= 2f)
        {
            Debug.Log("Encounter imminent!");
            _playerReference.EncounterAreaMovementTimer = 0;
            _encounterPossible = true;
            return;
        }
        _encounterPossible = false;
    }
    private bool CalculateEncounterChance()
    {
        float random_number = Random.Range(0f, 100f);
        if (random_number <= _encounterChancePercentage)
        {
            Debug.Log("*** Encounter started! ***");
            return true;
        }

        return false;
    }
}
