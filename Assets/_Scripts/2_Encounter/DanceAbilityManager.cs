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

    public static void LoadDancesFromResources()
    {
        var enemy_abilities = Resources.LoadAll("DanceAbilities" + Path.DirectorySeparatorChar + "Enemy", typeof(DanceAbility));
        foreach (var item in enemy_abilities)
        {
            _enemyDanceAbilities.Add(item as DanceAbility);
        }

        var player_abilities = Resources.LoadAll("DanceAbilities" + Path.DirectorySeparatorChar + "Player", typeof(DanceAbility));
        foreach (var item in player_abilities)
        {
            _playerDanceAbilities.Add(item as DanceAbility);
        }
    }
}
