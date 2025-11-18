using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour
{
    public static List<Card> hand;
    public static GameObject cardPrefab;
    public static int initIndex;
    public static GameObject gameplayCanvas;
    public static List<Card> deck;
    public static List<Card> discard;

    private void Awake()
    {
        cardPrefab = Resources.Load<GameObject>("Prefabs/CardPrefab");
        gameplayCanvas = GameObject.Find("GameplayCanvas");
        initIndex = 0;
        hand = new List<Card>();
        deck = new List<Card>();
        discard = new List<Card>();
        CreateStartingDeck();
        RefillHand(7);
    }

    public static void RefillHand(int maxHandCount) 
    {
        if (hand.Count < maxHandCount) 
        {
            int numToDraw = maxHandCount - hand.Count;
            for (int i = 0; i < numToDraw; i++)
            {
                if (CardsInDeck() == 0)
                {
                    for (int j = 0; j < discard.Count; j++) 
                    {
                        discard[j].SetDrawn(false);
                        discard[j].SetPlayed(false);
                    }
                    discard.Clear();
                    Debug.Log("Reshuffled discard into deck");
                }
                var card = deck[Random.Range(0, deck.Count)];
                while (card.Drawn() == true) 
                {
                    card = deck[Random.Range(0, deck.Count)];
                }
                card.SetDrawn(true);
                hand.Add(card);
                GameObject cardGO = Instantiate(cardPrefab, gameplayCanvas.transform);
                CardControl cardControl = cardGO.GetComponent<CardControl>();
                cardControl.SetCard(card);
            }
        }
    }

    private void CreateStartingDeck() 
    {
        for (int i = 0; i < 5; i++)
        {
            var card = new DamageCard();
            card.SetCardType(1);
            card.SetQueueIndex(initIndex);
            deck.Add(card);
            initIndex++;
        }
        for (int i = 0; i < 4; i++)
        {
            var card = new HealCard();
            card.SetCardType(1);
            card.SetQueueIndex(initIndex);
            deck.Add(card);
            initIndex++;
        }
        for (int i = 0; i < 3; i++)
        {
            var card = new ManaCard();
            card.SetCardType(1);
            card.SetQueueIndex(initIndex);
            deck.Add(card);
            initIndex++;
        }
        {
            var card = new Draw2();
            card.SetCardType(2);
            card.SetQueueIndex(initIndex);
            deck.Add(card);
            initIndex++;
        }
        {
            var card = new AOE();
            card.SetCardType(1);
            card.SetQueueIndex(initIndex);
            deck.Add(card);
            initIndex++;
        }
    }

    private static int CardsInDeck() 
    {
        int cardCount = 0;
        for (int i = 0; i < deck.Count; i++) 
        {
            if (!deck[i].Drawn()) 
            {
                cardCount++;
            }
        }
        return cardCount;
    }
}
