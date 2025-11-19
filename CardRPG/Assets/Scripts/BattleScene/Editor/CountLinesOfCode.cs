using UnityEngine;
using UnityEditor;
using System.IO;

public class CountLinesOfCode : EditorWindow
{
    private int totalLines = 0;

    [MenuItem("Tools/Count Lines of Code")]
    public static void ShowWindow()
    {
        GetWindow(typeof(CountLinesOfCode), false, "Line Counter");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Count Lines of Code"))
        {
            totalLines = CountLines();
            Debug.Log("Total Lines of Code: " + totalLines);
        }

        GUILayout.Label("Total Lines: " + totalLines);
    }

    private int CountLines()
    {
        string[] files = Directory.GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories);
        int lineCount = 0;

        foreach (string file in files)
        {
            lineCount += File.ReadAllLines(file).Length;
        }

        return lineCount;
    }
}