using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCard : Card
{
    public DamageCard() 
    {
        SetSprite(Resources.Load<Sprite>("Sprites/Cards/DamageCardSprite"));
    }

    override protected void CardEffect()
    {
        var cardString = "damage";
        Effect();
        TextReplayUIControl.actions.Add("Player used a " + cardString + " card");
        TextReplayUIControl.UpdateReplayUI();
    }

    private void Effect() 
    {
        if (PlayerControl.playerMana > 0)
        {
            BattleGameManager.target.ChangeHealth(-5);
            PlayerControl.ChangePlayerMana(-1);
        }
        else
        {
            Debug.Log("no mana left");
        }
    }
}