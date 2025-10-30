using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card
{
    private int queueIndex;
    private int cardType;
    private Color color;
    private bool played;

    public int GetQueueIndex()
    {
        return queueIndex;
    }

    public void SetQueueIndex(int queueIndex)
    {
        this.queueIndex = queueIndex;
    }

    public int GetCardType()
    {
        return cardType;
    }

    public void SetCardType(int cardType)
    {
        this.cardType = cardType;
        switch (cardType)
        {
            case 1:
                color = Color.blue;
                break;
            case 2:
                color = Color.green;
                break;
            case 3:
                color = Color.red;
                break;
        }
    }

    public Color GetColor()
    {
        return color;
    }

    public void SetPlayed(bool played) 
    {
        this.played = played;
    }

    public bool Played() 
    {
        return played;
    }

    public void PlayCard() 
    {
        switch (cardType) 
        {
            case 1:
                PlayerControl.ChangePlayerMana(2);
                break;
            case 2:
                if (PlayerControl.playerMana > 0)
                {
                    PlayerControl.ChangePlayerHealth(1);
                    PlayerControl.ChangePlayerMana(-1);
                }
                else 
                {
                    Debug.Log("no mana left");
                }
                break;
            case 3:
                if (PlayerControl.playerMana > 0)
                {
                    GameManager.enemies[GameManager.target].ChangeHealth(-1);
                    PlayerControl.ChangePlayerMana(-1);
                }
                else
                {
                    Debug.Log("no mana left");
                }
                break;
        }
    }
}
