using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static int playerHealth;
    public static int playerMana;

    private void Awake()
    {
        playerHealth = 10;
        playerMana = 5;
    }

    public static void ChangePlayerHealth(int healthChange) 
    {
        playerHealth += healthChange;
    }

    public static void ChangePlayerMana(int manaChange) 
    {
        playerMana += manaChange;
    }
}
