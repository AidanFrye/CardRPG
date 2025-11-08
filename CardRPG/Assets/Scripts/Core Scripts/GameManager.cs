using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    private GameObject enemyPrefab;
    private GameObject selector;
    public static int target;
    public static List<Enemy> enemies = new List<Enemy>();
    public static int enemyIndex = 0;
    public int enemyCount = 2;
    public Canvas gameplayCanvas;
    #endregion

    private void Awake()
    {
        selector = GameObject.Find("Selector");
        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyPrefab");
        SpawnEnemies();
    }

    private void Update()
    {
        var xOffset = target * 2;
        var yOffset = target * -1;
        selector.transform.position = new Vector2(6, 1) + new Vector2(xOffset, yOffset);
    }

    private void SpawnEnemies() 
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var enemy = new Enemy();
            enemy.SetQueueIndex(enemyIndex);
            enemy.SetEnemyType(Random.Range(1, 4));
            enemy.SetHealth(10);
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

