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
    void Awake()
    {
        Instantiate(playerPrefab, gameplayCanvas.transform);
        SpawnEnemy(Enemy.EnemyType.Bat);
    }

    void SpawnEnemy(EnemyType enemyType) 
    {
        var enemy = new Enemy();
        var type = enemySOs[(int)enemyType];
        enemy.SetEnemyType(enemyType);
        enemy.SetSprite(type.sprite);
        enemy.SetIdleClip(type.idleAnimation);
        enemy.SetAttackClip(type.attackAnimation);
        GameObject enemyGO = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity, gameplayCanvas.transform);
        EnemyAnimation animation = enemyGO.GetComponentInChildren<EnemyAnimation>();
        animation.transform.localScale = new Vector3(8, 8, 0);
        animation.SetupAnimations(enemy);
    }
}
