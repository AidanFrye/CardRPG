using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw2 : Card
{
    public Draw2() 
    {
        SetCardName("Draw2");
    }

    protected override void CardEffect() 
    {
        var cardString = "draw";
        HandControl.RefillHand(HandControl.hand.Count + 2);
        TextReplayUIControl.actions.Add("Player used a " + cardString + " card");
        TextReplayUIControl.UpdateReplayUI();
    }
}
