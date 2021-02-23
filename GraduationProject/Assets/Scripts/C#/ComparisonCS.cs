using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ComparisonCS : MonoBehaviour
{
    ExplorerCS csFile1;
    ExplorerCS csFile2;
    Text comparisonText;

    void Start()
    {
        GameObject text1 = GameObject.Find("ManagerCS1");
        GameObject text2 = GameObject.Find("ManagerCS2");
        GameObject textCompare = GameObject.Find("ComparisonTextCS");
        if (text1 != null)
        {
            csFile1 = text1.GetComponent<ExplorerCS>();
        }
        if (text2 != null)
        {
            csFile2 = text2.GetComponent<ExplorerCS>();
        }
        if (textCompare != null)
        {
            comparisonText = textCompare.GetComponent<Text>();
        }
    }

    void Update()
    {
        if (csFile1.readText && csFile2.readText)
            compareCS();
        if (csFile1.formatButton && csFile2.formatButton && csFile1.readText && csFile2.readText)
            compareCS();
    }

    private void compareCS()
    {
        string file1 = csFile1.eText.text;
        string file2 = csFile2.eText.text;
        if (file1 == file2) 
            comparisonText.text = "Equals: " + file1.Equals(file2);
        else 
            comparisonText.text = "Equals: " + file1.Equals(file2);
        if (string.Compare(file1, file2) == -1)
            comparisonText.text += "\n<color=#333333>CodeFile1</color> is less than <color=#333333>CodeFile2</color>";
        else if (string.Compare(file1, file2) == 0)
            comparisonText.text += "\n<color=#333333>CodeFile1</color> equals <color=#333333>CodeFile2</color>";
        else if (string.Compare(file1, file2) == 1)
            comparisonText.text += "\n<color=#333333>CodeFile1</color> is greater than <color=#333333>CodeFile2</color>";

        comparisonText.text += "\n<color=#333333>CodeFile1</color> got " + whiteSpaces(file1, file1.Length) + " whitespaces";
        comparisonText.text += "\n<color=#333333>CodeFile1</color> got " + newLines(file1, file1.Length) + " newlines";
        comparisonText.text += "\n<color=#333333>CodeFile1</color> got " + singleCommentary(file1, file1.Length) + " single-line comments";
        comparisonText.text += "\n<color=#333333>CodeFile1</color> got " + Regex.Matches(file1, "int").Count + " ints";
        comparisonText.text += "\n<color=#333333>CodeFile1</color> got " + Regex.Matches(file1, "double").Count + " doubles";
        comparisonText.text += "\n<color=#333333>CodeFile1</color> got " + Regex.Matches(file1, "float").Count + " floats";
        comparisonText.text += "\n<color=#333333>CodeFile1</color> got " + Regex.Matches(file1, "char").Count + " chars";
        comparisonText.text += "\n<color=#333333>CodeFile2</color> got " + whiteSpaces(file2, file2.Length) + " whitespaces";
        comparisonText.text += "\n<color=#333333>CodeFile2</color> got " + newLines(file2, file2.Length) + " newlines";
        comparisonText.text += "\n<color=#333333>CodeFile2</color> got " + singleCommentary(file2, file2.Length) + " single-line comments";
        comparisonText.text += "\n<color=#333333>CodeFile2</color> got " + Regex.Matches(file2, "int").Count + " ints";
        comparisonText.text += "\n<color=#333333>CodeFile2</color> got " + Regex.Matches(file2, "double").Count + " doubles";
        comparisonText.text += "\n<color=#333333>CodeFile2</color> got " + Regex.Matches(file2, "float").Count + " floats";
        comparisonText.text += "\n<color=#333333>CodeFile2</color> got " + Regex.Matches(file2, "char").Count + " chars";
    }

    private int whiteSpaces(string text, int length)
    {
        int whitespaces = 0;
        for (int i = 0; i < length - 1; i++)
        {
            if (text[i] == ' ')
                whitespaces++;
        }
        return whitespaces;
    }
    private int newLines(string text, int length)
    {
        int nl = 0;
        for (int i = 0; i < length - 1; i++)
        {
            if (text[i] == '\n')
                nl++;
        }
        return nl;
    }

    private int singleCommentary(string text, int length)
    {
        int comm = 0;
        for (int i = 0; i < length - 1; i++)
        {
            if (text[i] == '/' && text[i + 1] == '/')
                comm++;
        }
        return comm;
    }
}
