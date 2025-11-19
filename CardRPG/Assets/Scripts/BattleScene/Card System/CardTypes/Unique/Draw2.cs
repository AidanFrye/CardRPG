using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw2 : Card
{
    public Draw2() 
    {
        SetSprite(Resources.Load<Sprite>("Sprites/Cards/Draw2CardSprite"));
    }

    protected override void CardEffect() 
    {
        var cardString = "draw 2";
        Effect();
        TextReplayUIControl.actions.Add("Player used a " + cardString + " card");
        TextReplayUIControl.UpdateReplayUI();
    }

    private void Effect() 
    {
        HandControl.RefillHand(HandControl.hand.Count + 2);
    }
}
