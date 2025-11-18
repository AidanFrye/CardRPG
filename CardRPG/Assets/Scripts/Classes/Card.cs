using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Card
{
    private int queueIndex;
    private int cardType;
    private Color color;
    private bool played;
    private bool hasEffects = false;
    private string cardName;
    private bool drawn = false;
    public string cardString = "";
    //check this if replay text is wrong

    #region Get Set CardName
    public void SetCardName(string cardName) 
    {
        this.cardName = cardName;
    }

    public string GetCardName() 
    {
        return cardName;
    }
    #endregion

    #region Get Set Drawn
    public bool Drawn() 
    {
        return drawn;
    }

    public void SetDrawn(bool drawn) 
    {
        this.drawn = drawn;
    }
    #endregion

    #region Get Set HasEffects
    public bool HasEffects() 
    {
        return hasEffects;
    }

    public void SetHasEffects(bool hasEffects) 
    {
        this.hasEffects = hasEffects;
    }
    #endregion

    #region Get Set QueueIndex
    public int GetQueueIndex()
    {
        return queueIndex;
    }

    public void SetQueueIndex(int queueIndex)
    {
        this.queueIndex = queueIndex;
    }
    #endregion

    #region Get Set CardType
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
    #endregion

    #region Get Color
    public Color GetColor()
    {
        return color;
    }
    #endregion

    #region Get Set Played
    public void SetPlayed(bool played) 
    {
        this.played = played;
    }

    public bool Played() 
    {
        return played;
    }
    #endregion 

    public void PlayCard() 
    {
        SetPlayed(true);
        CardEffect();
    }


    protected abstract void CardEffect();
        //implemented by child classes to create unique effects
}
