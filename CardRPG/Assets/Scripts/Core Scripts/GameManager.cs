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
        Dragon,
        Random
    }
    #endregion

    private void Awake()
    {
        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyPrefab");
        SpawnEnemies(2, EnemyType.Random);
    }
    private void SpawnEnemies(int enemyCount, EnemyType enemyType) 
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var type = enemySOs[0];
            if(enemyType == EnemyType.Random) 
            {
                type = enemySOs[Random.Range(0, 2)];
            }
            else 
            {
                type = enemySOs[(int)enemyType];
            }
            var enemy = new Enemy();
            enemy.SetQueueIndex(enemyIndex);
            enemy.SetEnemyType(enemyType);
            enemy.SetMaxHealth(type.maxHealth);
            enemy.SetDamage(type.damage);
            enemy.SetHealth(enemy.GetMaxHealth());
            enemy.SetQueueIndex(i);
            enemy.SetSprite(type.sprite);
            enemies.Add(enemy);
            var xOffset = i * 2;
            var yOffset = i * -1;
            GameObject enemyGO = Instantiate(enemyPrefab, new Vector2(5.5f, 0) + new Vector2(xOffset, yOffset), Quaternion.identity, gameplayCanvas.transform);
            EnemyControl enemyControl = enemyGO.GetComponent<EnemyControl>();
            enemyControl.SetEnemy(enemy);
            enemyIndex++;
        }
    }
}

