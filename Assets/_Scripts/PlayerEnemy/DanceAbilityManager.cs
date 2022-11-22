using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DanceAbilityManager
{
    public static List<DanceAbility> PlayerDanceAbilities { get { return _playerDanceAbilities; } private set { } }
    private static List<DanceAbility> _playerDanceAbilities = new List<DanceAbility>();
    public static List<DanceAbility> EnemyDanceAbilities { get { return _enemyDanceAbilities; } private set { } }
    private static List<DanceAbility> _enemyDanceAbilities = new List<DanceAbility>();

    private static bool _dancesLoaded = false;
    public static void LoadDancesFromResources()
    {
        if(!_dancesLoaded)
        { 
            _dancesLoaded = true;
            var shared_abilities = Resources.LoadAll("DanceAbilities" + Path.DirectorySeparatorChar + "Shared", typeof(DanceAbility));
            foreach (var item in shared_abilities)
            {
                _playerDanceAbilities.Add(item as DanceAbility);
                _enemyDanceAbilities.Add(item as DanceAbility);
                Debug.Log("Loaded SHARED dance: " + item.name);
            }

            var enemy_abilities = Resources.LoadAll("DanceAbilities" + Path.DirectorySeparatorChar + "Enemy", typeof(DanceAbility));
            foreach (var item in enemy_abilities)
            {
                _enemyDanceAbilities.Add(item as DanceAbility);
                Debug.Log("Loaded ENEMY dance: " + item.name);
            }

            var player_abilities = Resources.LoadAll("DanceAbilities" + Path.DirectorySeparatorChar + "Player", typeof(DanceAbility));
            foreach (var item in player_abilities)
            {
                _playerDanceAbilities.Add(item as DanceAbility);
                Debug.Log("Loaded PLAYER dance: " + item.name);
            }
        }
    }
}
