using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldPositionSaver : MonoBehaviour
{
    public GameObject _player;

    // Save player position to the GameDataManager
    public void SavePlayerPosition()
    {
        GameDataManager.SavePositionToGameData(_player.transform.position);
    }
}
