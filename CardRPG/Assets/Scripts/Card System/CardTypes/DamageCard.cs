using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCard : Card
{
    override protected void CardEffect()
    {
        var cardString = "damage";
        if (PlayerControl.playerMana > 0)
        {
            GameManager.enemies[GameManager.target].ChangeHealth(-1);
            PlayerControl.ChangePlayerMana(-1);
        }
        else
        {
            Debug.Log("no mana left");
        }
        TextReplayUIControl.actions.Add("Player used a " + cardString + " card");
        TextReplayUIControl.UpdateReplayUI();
    }
}