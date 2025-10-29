using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour
{
    public static List<Card> hand;
    public static GameObject cardPrefab;
    public static int initIndex;

    private void Awake()
    {
        cardPrefab = Resources.Load<GameObject>("Prefabs/Basic Card");
        initIndex = 0;
        hand = new List<Card>();
        RefillHand();
    }

    public static void RefillHand() 
    {
        if (hand.Count < 7) 
        {
            int numToDraw = 7 - hand.Count;
            for (int i = 0; i < numToDraw; i++)
            {
                var card = new Card();
                hand.Add(card);
                card.SetQueueIndex(initIndex);
                card.SetCardType(Random.Range(1, 4));
                GameObject cardGO = Instantiate(cardPrefab);
                CardControl ui = cardGO.GetComponent<CardControl>();
                ui.SetCard(card);
                initIndex++;
            }
        }
    }
}
