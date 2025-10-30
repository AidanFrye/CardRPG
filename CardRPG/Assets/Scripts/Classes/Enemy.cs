using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    private int health;
    private int queueIndex;
    private int enemyType;

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

    public int GetQueueIndex() 
    {
        return queueIndex;
    }

    public void SetQueueIndex(int queueIndex) 
    {
        this.queueIndex = queueIndex;
    }

    public int GetEnemyType() 
    {
        return enemyType;
    }

    public void SetEnemyType(int enemyType) 
    {
        this.enemyType = enemyType;
    }
}
