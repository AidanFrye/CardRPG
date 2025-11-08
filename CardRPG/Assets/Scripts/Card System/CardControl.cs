using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControl : MonoBehaviour
{
    Card card;
    private GameObject queue;
    private GameObject cardController;
    private void Awake()
    {
        cardController = GameObject.Find("GameManager");
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
        if (TurnManager.currentState != TurnManager.TurnState.Player)
        {
            return;
        }
        if (card.GetCardType() != 4)
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
        else 
        {
            HandControl.hand.Remove(card);
            HandControl.discard.Add(card);
            card.PlayCard();
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
            transform.localPosition = new Vector2(-425f, -113f) + new Vector2(60f * QueueControl.queue.IndexOf(card), 0);
        }
        else if (HandControl.hand.Contains(card)) 
        {
            transform.localPosition = new Vector2(-425f, -211f) + new Vector2(HandControl.hand.IndexOf(card) * 60f, 0);
        }
        if (card.Played()) 
        {
            //AddCardToDiscard();
            Destroy(gameObject);
        }
    }
}
