using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy;
using Cinemachine;

public class OverworldGameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject gameplayCanvas;
    [SerializeField] private List<EnemyScriptableObject> enemySOs;
    [SerializeField] private CinemachineVirtualCamera cinemachineCamera;

    EnemyScriptableObject type;
    void Awake()
    {
        GameObject player = Instantiate(playerPrefab, gameplayCanvas.transform);
        for (int i = 0; i < Random.Range(2, 5); i++)
        {
            SpawnEnemy(Enemy.EnemyType.Random);
        }
        cinemachineCamera.LookAt = player.transform;
        cinemachineCamera.Follow = player.transform;
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
        GameObject enemyGO = Instantiate(enemyPrefab, new Vector3(Random.Range(-4, 5), Random.Range(-3, 4), 0), Quaternion.identity, gameplayCanvas.transform);
        EnemyAnimation animation = enemyGO.GetComponentInChildren<EnemyAnimation>();
        OverworldEnemyController controller = enemyGO.GetComponent<OverworldEnemyController>();
        controller.enemy = enemy;
        animation.transform.localScale = new Vector3(8, 8, 0);
        animation.SetupAnimations(enemy);
    }
}
