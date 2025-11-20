using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGameManager : MonoBehaviour
{
    #region Variables
    private GameObject enemyPrefab;
    private GameObject playerPrefab;
    public static int target;
    public static List<Enemy> enemies = new();
    public static int enemyIndex = 0;
    public Canvas gameplayCanvas;

    [SerializeField] private List<EnemyScriptableObject> enemySOs;
    #endregion

    private void Awake()
    {
        enemyPrefab = Resources.Load<GameObject>("Prefabs/BattleScene/EnemyPrefab");
        playerPrefab = Resources.Load<GameObject>("Prefabs/BattleScene/PlayerPrefab");
        var player = Instantiate(playerPrefab, gameplayCanvas.transform);
        player.transform.localPosition = new Vector3(-392, 9.5f, 0);
        SpawnEnemies(2, EncounterManager.Instance.encounterType);
    }
    private void SpawnEnemies(int enemyCount, Enemy.EnemyType enemyType) 
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var type = enemySOs[0];
            if(enemyType == Enemy.EnemyType.Random) 
            {
                type = enemySOs[Random.Range(0, 2)];
            }
            else 
            {
                type = enemySOs[(int)enemyType];
            }
            var enemy = new Enemy();
            enemy.SetQueueIndex(enemyIndex);
            enemy.SetEnemyType(type.enemyType);
            enemy.SetMaxHealth(type.maxHealth);
            enemy.SetDamage(type.damage);
            enemy.SetHealth(enemy.GetMaxHealth());
            enemy.SetQueueIndex(i);
            enemy.SetSprite(type.sprite);
            enemy.SetIdleClip(type.idleAnimation);
            enemy.SetAttackClip(type.attackAnimation);
            enemies.Add(enemy);
            var xOffset = i * 2;
            var yOffset = i * -1;
            GameObject enemyGO = Instantiate(enemyPrefab, new Vector3(5.5f, 0f, 0f) + new Vector3(xOffset, yOffset, 0f), Quaternion.identity, gameplayCanvas.transform);
            EnemyControl enemyControl = enemyGO.GetComponent<EnemyControl>();
            enemyControl.SetEnemy(enemy);
            EnemyAnimation animation = enemyGO.GetComponentInChildren<EnemyAnimation>();
            animation.SetupAnimations(enemy);
            enemyIndex++;
        }
    }
}

