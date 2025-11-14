using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    private GameObject enemyPrefab;
    public static int target;
    public static List<Enemy> enemies = new List<Enemy>();
    public static int enemyIndex = 0;
    public Canvas gameplayCanvas;

    [SerializeField] private List<EnemyScriptableObject> enemySOs;
    #endregion

    #region EnemyTypeEnum
    public enum EnemyType
    {
        Goblin,
        Skeleton,
        Dragon
    }
    #endregion

    private void Awake()
    {
        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyPrefab");
        SpawnEnemies(2, EnemyType.Goblin);
    }
    private void SpawnEnemies(int enemyCount, EnemyType enemyType) 
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var enemy = new Enemy();
            var type = enemySOs[(int)enemyType];
            enemy.SetQueueIndex(enemyIndex);
            enemy.SetEnemyType(enemyType);
            enemy.SetMaxHealth(type.maxHealth);
            enemy.SetDamage(type.damage);
            enemy.SetHealth(enemy.GetMaxHealth());
            enemy.SetQueueIndex(i);
            enemies.Add(enemy);
            var xOffset = i * 2;
            var yOffset = i * -1;
            GameObject enemyGO = Instantiate(enemyPrefab, new Vector2(6, 0) + new Vector2(xOffset, yOffset), Quaternion.identity, gameplayCanvas.transform);
            EnemyControl enemyControl = enemyGO.GetComponent<EnemyControl>();
            enemyControl.SetEnemy(enemy);
            enemyIndex++;
        }
    }
}

