using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    Enemy enemy;
    //[SerializeField] private GameObject highlight;
    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject spriteObject;
    private GameObject selector;
    private Transform healthCanvas;
    private GameObject healthbar;
    //selector functions just fine, add selector prefab and uncomment selector lines if you want to use it again

    private void Awake()
    {
        healthCanvas = transform.parent.Find("UI").Find("HealthCanvas").transform;
        //selector = transform.parent.Find("Selector").gameObject;
        healthbar = Instantiate(healthBarPrefab, transform);
        healthbar.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        healthbar.transform.localPosition = new Vector3(-0.982825f, 1, 0);
        spriteObject.transform.localScale = new Vector3(8, 8, 0);
    }

    public void SetEnemy(Enemy enemy) 
    {
        this.enemy = enemy;
        spriteRenderer.sprite = enemy.GetSprite();
        spriteRenderer.flipX = true;
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
        ProcessHealthChange();
        //ProcessTargeting();
    }

    void ProcessHealthChange() 
    {
        if (enemy.GetHealth() <= 0)
        {
            Destroy(gameObject);
        }
        var currentHealth = healthbar.transform.Find("CurrentHealth");
        currentHealth.transform.localScale = new Vector3((float)enemy.GetHealth() / (float)enemy.GetMaxHealth(), 1);
    }

    void ProcessTargeting() 
    {
        if (GameManager.target == enemy.GetQueueIndex())
        {
            //highlight.SetActive(true);
            selector.transform.SetParent(transform, false);
            selector.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            selector.transform.localPosition = new Vector3(0, 1.3f, 0);
            
        }
        else
        {
            //highlight.SetActive(false);
        }
    }
}
