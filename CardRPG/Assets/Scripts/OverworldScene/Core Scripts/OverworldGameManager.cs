using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy;

public class OverworldGameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject gameplayCanvas;
    [SerializeField] private List<EnemyScriptableObject> enemySOs;

    EnemyScriptableObject type;
    void Awake()
    {
        Instantiate(playerPrefab, gameplayCanvas.transform);
        SpawnEnemy(Enemy.EnemyType.Random);
    }

    void SpawnEnemy(EnemyType enemyType) 
    {
        var enemy = new Enemy();
        if (enemyType == Enemy.EnemyType.Random)
        {
            type = enemySOs[Random.Range(0, 2)];
        }
        else
        {
            type = enemySOs[(int)enemyType];
        }
        enemy.SetEnemyType(type.enemyType);
        enemy.SetSprite(type.sprite);
        enemy.SetIdleClip(type.idleAnimation);
        enemy.SetAttackClip(type.attackAnimation);
        GameObject enemyGO = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity, gameplayCanvas.transform);
        EnemyAnimation animation = enemyGO.GetComponentInChildren<EnemyAnimation>();
        OverworldEnemyController controller = enemyGO.GetComponent<OverworldEnemyController>();
        controller.enemy = enemy;
        animation.transform.localScale = new Vector3(8, 8, 0);
        animation.SetupAnimations(enemy);
    }
}
