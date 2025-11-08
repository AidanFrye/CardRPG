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
    private string cardName;
    private bool drawn = false;

    public void SetCardName(string cardName) 
    {
        this.cardName = cardName;
    }

    public string GetCardName() 
    {
        return cardName;
    }

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
            case 1: //mana
                color = Color.blue;
                break;
            case 2: //health
                color = Color.green;
                break;
            case 3: //damage
                color = Color.red;
                break;
            case 4: //unique
                color = Color.yellow;
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
        SetPlayed(true);
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
            case 4:
                UniqueEffect();
                break;
        }
        TextReplayUIControl.actions.Add("Player used a " + cardString + " card");
        TextReplayUIControl.UpdateReplayUI();
    }

    private void UniqueEffect() 
    {
        switch (cardName) 
        {
            case "Draw 2":
                Debug.Log("drew 2 cards");
                HandControl.RefillHand(8);
                break;
        }
    }
}
