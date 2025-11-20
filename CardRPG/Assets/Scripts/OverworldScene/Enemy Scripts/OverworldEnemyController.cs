using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OverworldEnemyController : MonoBehaviour
{
    private Vector2 target;
    private Rigidbody2D rb;
    private bool right;
    private bool up;
    public Enemy enemy;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(MovementLoop());
    }

    void PickPoint() 
    {
        float xPos = Random.Range(-3, 4);
        float yPos = Random.Range(-2, 3);
        target = new Vector2(xPos, yPos);
        right = rb.position.x < target.x;
        up = rb.position.y < target.y;
    }

    IEnumerator MovementLoop()
    {
        while (true)
        {
            PickPoint();
            yield return TravelToPoint();
            yield return new WaitForSeconds(Random.Range(2, 6));
        }
    }
    IEnumerator TravelToPoint()
    {
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        float speed = 7f;

        while (true)
        {
            Vector2 pos = rb.position;
            Vector2 dir = (target - pos);
            if (dir.magnitude < 0.05f)
            {
                break;
            }
            if (dir.x != 0)
            {
                sprite.flipX = dir.x < 0;
            }
            Vector2 move = dir.normalized * speed * Time.deltaTime;
            rb.MovePosition(pos + move);

            yield return null;
        }

        Debug.Log("Reached target!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            EncounterManager.Instance.TriggerEncounter(enemy.GetEnemyType());
        }
    }

    private void LateUpdate()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
    }
}
