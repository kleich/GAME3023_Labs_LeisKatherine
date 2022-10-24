using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

/// <summary>
/// Static class for holding game data and saving/loading using FileManager.
/// </summary>

public static class GameDataManager
{
    public static Vector2 PlayerPosition { get { return _playerPosition; } private set { } }
    private static Vector2 _playerPosition;
    public static bool WasDataLoaded { get { return _wasDataLoaded; } private set { } }
    private static bool _wasDataLoaded;
    private static string _characterDataFileName = "characterdata";

    public static bool DoesCharacterDataExist()
    {
        return FileManager.DoesFileExist(_characterDataFileName);
    }
    public static void Load()
    {
        string[] raw_data = null;
        if(FileManager.ReadFromFile(_characterDataFileName, out raw_data))
        {
            string[] split_data = raw_data[0].Split(',', System.StringSplitOptions.RemoveEmptyEntries);
            _playerPosition.x = float.Parse(split_data[0]);
            _playerPosition.y = float.Parse(split_data[1]);
            _wasDataLoaded = true;
            return;
        }
        _wasDataLoaded = false;
    }

    public static void SavePositionToGameData(Vector2 player_position)
    {
        _playerPosition = player_position;
    }

    public static void Save()
    {
        string[] position = new string[2];

        position[0] = $"{_playerPosition.x},{_playerPosition.y}";
        FileManager.SaveToFile(_characterDataFileName, position);
    }

    public static void Delete()
    {
        _wasDataLoaded = false;
        if (DoesCharacterDataExist())
            FileManager.DeleteFile(_characterDataFileName);
    }
}
