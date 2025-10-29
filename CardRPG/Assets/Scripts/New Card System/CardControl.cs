using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControl : MonoBehaviour
{
    private int index;
    Card card;
    private GameObject queue;
    private GameObject cardController;
    private void Awake()
    {
        cardController = GameObject.Find("CardController");
        queue = GameObject.Find("Queue");
    }

    private void Update()
    {
        UpdatePositionUI();
    }

    public void SetCard(Card assignedCard) 
    {
        card = assignedCard;
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = card.GetColor();
    }

    private void OnMouseDown()
    {
        if (HandControl.hand.Contains(card))
        {
            AddCardToQueue();
        }
        else if (QueueControl.queue.Contains(card)) 
        {
            AddCardToHand();
        }
    }

    private void AddCardToQueue() 
    {
        HandControl.hand.Remove(card);
        QueueControl.queue.Add(card);
    }
    private void AddCardToHand()
    {
        QueueControl.queue.Remove(card);
        HandControl.hand.Add(card);
    }

    private void UpdatePositionUI() 
    {
        if (QueueControl.queue.Contains(card))
        {
            transform.parent = queue.transform;
            transform.localPosition = new Vector2(-0.36f, -0.35f) + new Vector2(0.25f * QueueControl.queue.IndexOf(card), 0);
        }
        else if (HandControl.hand.Contains(card)) 
        {
            transform.parent = cardController.transform;
            transform.localPosition = new Vector2(-7.29f, -2.18f) + new Vector2(HandControl.hand.IndexOf(card) * 2.1f, 0);
        }
        if (card.Played()) 
        {
            Destroy(gameObject);
        }
    }
}
