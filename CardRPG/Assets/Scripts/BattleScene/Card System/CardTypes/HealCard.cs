using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCard : Card
{
    public HealCard()
    {
        SetSprite(Resources.Load<Sprite>("Sprites/Cards/HealCardSprite"));
    }

    override protected void CardEffect() 
    {
        var cardString = "heal";
        Effect();
        TextReplayUIControl.actions.Add("Player used a " + cardString + " card");
        TextReplayUIControl.UpdateReplayUI();
    }

    private void Effect() 
    {
        if (PlayerControl.playerMana > 0)
        {
            if (PlayerControl.playerHealth < 10)
            {
                PlayerControl.ChangePlayerHealth(1);
            }
            PlayerControl.ChangePlayerMana(-1);
        }
        else
        {
            Debug.Log("no mana left");
        }
    }
}
