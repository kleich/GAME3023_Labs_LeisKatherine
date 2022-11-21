using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyTypeManager
{
    private static bool _loaded = false;
    public static  List<Enemy> PossibleEnemies { get { return _enemies; } private set { } }
    private static List<EnemyData> _loadedEnemyData = new List<EnemyData>();
    private static List<Enemy> _enemies = new List<Enemy>();
    public static void LoadEnemiesFromResources()
    {
        if(!_loaded)
        {
            Object[] loaded_obj = Resources.LoadAll("Enemies", typeof(EnemyData));

            foreach (var go in loaded_obj)
            {
                _loadedEnemyData.Add(go as EnemyData);
            }

            foreach (var e in _loadedEnemyData)
            {
                _enemies.Add(new Enemy(e.Name, e.Hue, e.Description, e.Speed, e.MaxEnergy, e.DanceMoves));
            }

            foreach (var item in _enemies)
            {
                Debug.Log(item.Name);
            }
        }
    }
}
