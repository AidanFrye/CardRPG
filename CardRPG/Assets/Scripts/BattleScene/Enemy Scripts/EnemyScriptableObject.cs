using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyType", menuName = "Enemy/Enemy Type")]
public class EnemyScriptableObject : ScriptableObject
{
    [Header("Base Stats")]
    public int maxHealth;
    public int damage;
    public int numInWave;
    public Enemy.EnemyType enemyType;

    [Header("Sprite Info")]
    public Sprite sprite;
    public float scale;

    [Header("Animation Clips")]
    public AnimationClip idleAnimation;
    public AnimationClip attackAnimation;
}
