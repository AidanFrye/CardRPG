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
    private string cardName;
    private bool drawn = false;
    public string cardString = "";
    private Sprite sprite;

    /*#region Get Set CardName
    public void SetCardName(string cardName) 
    {
        this.cardName = cardName;
    }

    public string GetCardName() 
    {
        return cardName;
    }
    #endregion*/

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
        //1 is spell (goes into the queue to be cast), 2 is cantrip (cast immediately)
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

    #region Get Set Sprite
    public Sprite GetSprite()
    {
        Debug.Log("returning sprite");
        return sprite;
    }

    public void SetSprite(Sprite sprite) 
    {
        Debug.Log("setting sprite");
        this.sprite = sprite;
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
