using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    private int health;
    private int queueIndex;
    private GameManager.EnemyType enemyType;
    private int maxHealth;
    private int damage;
    private Sprite sprite;

    #region Get Set Damage
    public int GetDamage() 
    {
        return damage;
    }

    public void SetDamage(int damage) 
    {
        this.damage = damage;
    }
    #endregion

    #region Get Set Change Health

    public int GetHealth() 
    {
        return health;
    }

    public void SetHealth(int health) 
    {
        this.health = health;
    }
    public void ChangeHealth(int health)
    {
        this.health += health;
    }
    #endregion

    #region Get Set MaxHealth
    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }
    #endregion

    #region Get Set QueueIndex
    public int GetQueueIndex() 
    {
        return queueIndex;
    }

    public void SetQueueIndex(int queueIndex) 
    {
        this.queueIndex = queueIndex;
    }
    #endregion

    #region Get Set Sprite
    public Sprite GetSprite()
    {
        return sprite;
    }

    public void SetSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }
    #endregion

    #region Get Set EnemyType
    public GameManager.EnemyType GetEnemyType() 
    {
        return enemyType;
    }

    public void SetEnemyType(GameManager.EnemyType enemyType) 
    {
        this.enemyType = enemyType;
    }
    #endregion
}
