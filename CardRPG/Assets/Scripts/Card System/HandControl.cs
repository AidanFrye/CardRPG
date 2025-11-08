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
        RefillHand();
    }

    public static void RefillHand() 
    {
        if (hand.Count < 7) 
        {
            int numToDraw = 7 - hand.Count;
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
            for (int j = 0; j < deck.Count; j++)
            {
                if (!deck[j].Drawn())
                {
                    Debug.Log("card no " + j + " in deck is of card type: " + deck[j].GetCardType());
                }
            }
        }
    }

    private void CreateStartingDeck() 
    {
        for (int i = 0; i < 5; i++)
        {
            var card = new Card();
            card.SetCardType(3);
            card.SetHasEffects(false);
            card.SetQueueIndex(initIndex);
            deck.Add(card);
            initIndex++;
        }
        for (int i = 0; i < 4; i++)
        {
            var card = new Card();
            card.SetCardType(2);
            card.SetHasEffects(false);
            card.SetQueueIndex(initIndex);
            deck.Add(card);
            initIndex++;
        }
        for (int i = 0; i < 3; i++)
        {
            var card = new Card();
            card.SetCardType(1);
            card.SetHasEffects(false);
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
