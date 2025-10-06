using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public static List<Card> hand = new(7);
    public static int cardsInHand;
    public GameObject cardPrefab;
    // Start is called before the first frame update
    void Start()
    {
        cardsInHand = 0;
        StartCoroutine(loadHand());
    }

    public void loadNewHand() 
    {
        StartCoroutine(loadHand());
    }

    IEnumerator loadHand() 
    {
        QueueController.queue = new List<Card>();
        QueueController.cardsInQueue = 0;
        for (int i = 0; i < 7; i++)
        {
            cardsInHand++;
            Instantiate(cardPrefab, new Vector3(-6.82f + (2.43f * i), -3.48f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
