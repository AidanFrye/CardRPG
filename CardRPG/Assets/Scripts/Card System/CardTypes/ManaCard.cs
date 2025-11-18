using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaCard : Card
{
    override protected void CardEffect()
    {
        var cardString = "mana";
        PlayerControl.ChangePlayerMana(2);
        TextReplayUIControl.actions.Add("Player used a " + cardString + " card");
        TextReplayUIControl.UpdateReplayUI();
    }
}


