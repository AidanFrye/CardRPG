using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextReplayUIControl : MonoBehaviour
{
    public static TMP_Text textUI;
    public static List<string> actions = new List<string>();

    public void Awake()
    {
        textUI = FindObjectOfType<TMP_Text>();
    }

    public static void UpdateReplayUI()
    {
        textUI.text = "";
        if (actions.Count > 4)
        {
            actions.RemoveAt(0);
        }
        for (int i = actions.Count - 1; i >= 0; i--)
        {
            textUI.text += actions[i] + "\n";
        }
    }
}
