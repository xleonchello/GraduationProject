using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ComparisonVB : MonoBehaviour
{
    ExplorerVB vbFile1;
    ExplorerVB vbFile2;
    Text comparisonText;

    void Start()
    {
        GameObject text1 = GameObject.Find("ManagerVB1");
        GameObject text2 = GameObject.Find("ManagerVB2");
        GameObject textCompare = GameObject.Find("ComparisonTextVB");
        if (text1 != null)
        {
            vbFile1 = text1.GetComponent<ExplorerVB>();
        }
        if (text2 != null)
        {
            vbFile2 = text2.GetComponent<ExplorerVB>();
        }
        if (textCompare != null)
        {
            comparisonText = textCompare.GetComponent<Text>();
        }
    }

    void Update()
    {
        if (vbFile1.readText && vbFile2.readText)
            CompareVB();
        if (vbFile1.formatButton && vbFile2.formatButton && vbFile1.readText && vbFile2.readText)
            CompareVB();
    }

    private void CompareVB()
    {
        string file1 = vbFile1.eText.text;
        string file2 = vbFile2.eText.text;
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
        comparisonText.text += "\n<color=#333333>CodeFile1</color> got " + Regex.Matches(file1, "Integer").Count + " Integers";
        comparisonText.text += "\n<color=#333333>CodeFile1</color> got " + Regex.Matches(file1, "Long").Count + " Longs";
        comparisonText.text += "\n<color=#333333>CodeFile1</color> got " + Regex.Matches(file1, "Double").Count + " Doubles";
        comparisonText.text += "\n<color=#333333>CodeFile1</color> got " + Regex.Matches(file1, "Single").Count + " Singles";
        comparisonText.text += "\n<color=#333333>CodeFile2</color> got " + whiteSpaces(file2, file2.Length) + " whitespaces";
        comparisonText.text += "\n<color=#333333>CodeFile2</color> got " + newLines(file2, file2.Length) + " newlines";
        comparisonText.text += "\n<color=#333333>CodeFile2</color> got " + singleCommentary(file2, file2.Length) + " single-line comments";
        comparisonText.text += "\n<color=#333333>CodeFile2</color> got " + Regex.Matches(file2, "Integer").Count + " Integers";
        comparisonText.text += "\n<color=#333333>CodeFile2</color> got " + Regex.Matches(file2, "Long").Count + " Longs";
        comparisonText.text += "\n<color=#333333>CodeFile2</color> got " + Regex.Matches(file2, "Double").Count + " Doubles";
        comparisonText.text += "\n<color=#333333>CodeFile2</color> got " + Regex.Matches(file2, "Single").Count + " Singles";
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
            if (text[i] == '\'')
                comm++;
        }
        return comm;
    }
}
