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
    private bool hasEffects = false;
    private bool drawn = false;

    public bool Drawn() 
    {
        return drawn;
    }

    public void SetDrawn(bool drawn) 
    {
        this.drawn = drawn;
    }

    public bool HasEffects() 
    {
        return hasEffects;
    }

    public void SetHasEffects(bool hasEffects) 
    {
        this.hasEffects = hasEffects;
    }

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
        string cardString = "";
        switch (cardType) 
        {
            case 1:
                PlayerControl.ChangePlayerMana(2);
                cardString = "mana";
                break;
            case 2:
                if (PlayerControl.playerMana > 0)
                {
                    if (PlayerControl.playerHealth < 10)
                    {
                        PlayerControl.ChangePlayerHealth(1);
                    }
                    PlayerControl.ChangePlayerMana(-1);
                    cardString = "heal";
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
                    cardString = "damage";
                }
                else
                {
                    Debug.Log("no mana left");
                }
                break;
        }
        TextReplayUIControl.actions.Add("Player used a " + cardString + " card");
        TextReplayUIControl.UpdateReplayUI();
    }
}
