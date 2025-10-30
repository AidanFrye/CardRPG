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
        cardPrefab = Resources.Load<GameObject>("Prefabs/CardPrefab");
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
                card.SetCardType(ChooseCardType());
                GameObject cardGO = Instantiate(cardPrefab);
                CardControl cardControl = cardGO.GetComponent<CardControl>();
                cardControl.SetCard(card);
                initIndex++;
            }
        }
    }

    private static int ChooseCardType() 
    {
        var rand = Random.Range(1, 11);
        if (rand < 3)
        {
            return 1; //20 % for mana card
        }
        else if (rand < 6)
        {
            return 2; //30 % for health card
        }
        else 
        {
            return 3; //50 % for damage card
        }
    }
}
