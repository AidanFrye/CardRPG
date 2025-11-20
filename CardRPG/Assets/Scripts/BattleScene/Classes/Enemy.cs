using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    private int health;
    private int queueIndex;
    private EnemyType enemyType;
    private int maxHealth;
    private int damage;
    private Sprite sprite;

    private AnimationClip idleClip;
    private AnimationClip attackClip;

    private Animator animator;

    public enum EnemyType
    {
        Bat,
        Dragon,
        Skeleton,
        Random
    }

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
    public EnemyType GetEnemyType() 
    {
        return enemyType;
    }

    public void SetEnemyType(EnemyType enemyType) 
    {
        this.enemyType = enemyType;
    }
    #endregion

    #region Get Set Animator
    public Animator GetAnimator() 
    {
        return animator;
    }
    public void SetAnimator(Animator animator) 
    {
        this.animator = animator;
    }
    #endregion

    #region Get Set IdleClip
    public AnimationClip GetIdleClip() 
    {
        return idleClip;
    }

    public void SetIdleClip(AnimationClip idleClip) 
    {
        this.idleClip = idleClip;
    }
    #endregion

    #region Get Set AttackClip
    public AnimationClip GetAttackClip()
    {
        return attackClip;
    }

    public void SetAttackClip(AnimationClip attackClip)
    {
        this.attackClip = attackClip;
    }
    #endregion
}
