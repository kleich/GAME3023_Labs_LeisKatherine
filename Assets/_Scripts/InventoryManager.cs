using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryPanel;
    private bool _inventoryVisible = false;

    private void Start()
    {
        InventoryPanel.SetActive(_inventoryVisible);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            _inventoryVisible = !_inventoryVisible;
            InventoryPanel.SetActive(_inventoryVisible);
        }
    }
}
