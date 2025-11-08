using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBarController : MonoBehaviour
{
    public static GameObject healthBar;

    private void Awake()
    {
        healthBar = this.gameObject;
    }
    public static void UpdateHealthUI()
    {
        healthBar.transform.localScale = new Vector3((float)PlayerControl.playerHealth / (float)PlayerControl.playerMaxHealth, 1);
    }
}
