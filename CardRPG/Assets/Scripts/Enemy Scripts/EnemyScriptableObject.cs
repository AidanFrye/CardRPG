using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyType", menuName = "Enemy/Enemy Type")]
public class EnemyScriptableObject : ScriptableObject
{
    [Header("Base Stats")]
    public int maxHealth;
    public int damage;
    public GameManager.EnemyType enemyType;
}
