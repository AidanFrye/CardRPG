using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaCard : Card
{
    public ManaCard() 
    {
        SetSprite(Resources.Load<Sprite>("Sprites/Cards/ManaCardSprite"));
    }

    override protected void CardEffect()
    {
        var cardString = "mana";
        Effect();
        TextReplayUIControl.actions.Add("Player used a " + cardString + " card");
        TextReplayUIControl.UpdateReplayUI();
    }

    private void Effect() 
    {
        PlayerControl.ChangePlayerMana(2);
    }
}


