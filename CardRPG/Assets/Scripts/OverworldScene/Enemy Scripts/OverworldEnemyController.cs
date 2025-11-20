using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OverworldEnemyController : MonoBehaviour
{
    private Vector3 target;

    private void Start()
    {
        StartCoroutine(MovementLoop());
    }

    void PickPoint() 
    {
        target = Vector3.zero + new Vector3(Random.Range(-100, 101), Random.Range(-100, 101), 0);
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
        bool foundPosX = false;
        bool foundPosY = false;
        var sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        while (!(foundPosY && foundPosX)) 
        {
            if (!foundPosX)
            {
                if (transform.localPosition.x < (target.x - 3))
                {
                    transform.localPosition += new Vector3(32f * Time.deltaTime, 0, 0);
                    sprite.flipX = false;
                }
                else if (transform.localPosition.x > (target.x + 3))
                {
                    transform.localPosition -= new Vector3(32f * Time.deltaTime, 0, 0);
                    sprite.flipX = true;
                }
                else
                {
                    foundPosX = true;
                    Debug.Log("found x pos");
                }
            }
            if (!foundPosY)
            {
                if (transform.localPosition.y < (target.y - 3))
                {
                    transform.localPosition += new Vector3(0, 32f * Time.deltaTime, 0);
                }
                else if (transform.localPosition.y > (target.y + 3))
                {
                    transform.localPosition -= new Vector3(0, 32f * Time.deltaTime, 0);
                }
                else
                {
                    foundPosY = true;
                    Debug.Log("found y pos");
                }
            }
            yield return null;
        }
        Debug.Log("one loop");
    }

    private void LateUpdate()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
    }
}
