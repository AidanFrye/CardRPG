using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    Enemy enemy;

    public void SetEnemy(Enemy enemy) 
    {
        this.enemy = enemy;
    }
    private void OnMouseDown()
    {
        gameObject.transform.localScale -= new Vector3(3f, 3f);
    }
    private void OnMouseUp()
    {
        gameObject.transform.localScale += new Vector3(3f, 3f);
        Debug.Log("Enemy number " + enemy.GetQueueIndex() + " selected.");
        GameManager.target = enemy.GetQueueIndex();
        Debug.Log("The health of the enemy is: " + GameManager.enemies[GameManager.target].GetHealth());
    }

    private void Update()
    {
        if (enemy.GetHealth() <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
