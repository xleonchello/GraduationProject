using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ColorCodeCS : MonoBehaviour
{
    ExplorerCS csFile1;
    ExplorerCS csFile2;
    public Button colorButton;
    public bool allisColored = false;
    public List<string> keywordsCS = new List<string>()
    {
        "abstract",
        "as",
        "base",
        "break",
        "bool",
        "by",
        "byte",
        "case",
        "catch",
        "char",
        "checked",
        "class",
        "const",
        "continue",
        "decimal",
        "default",
        "delegate",
        "do",
        "double",
        "else",
        "enum",
        "event",
        "explicit",
        "extern",
        "false",
        "finally",
        "fixed",
        "float",
        "for",
        "foreach",
        "from",
        "group",
        "if",
        "implicit",
        "in",
        "int",
        "interface",
        "internal",
        "into",
        "is",
        "lock",
        "long",
        "namespace",
        "new",
        "null",
        "object",
        "operator",
        "out",
        "override",
        "params",
        "private",
        "protected",
        "public",
        "readonly",
        "ref",
        "return",
        "sbyte",
        "sealed",
        "select",
        "sizeof",
        "short",
        "stackalloc",
        "static",
        "string",
        "struct",
        "switch",
        "this",
        "throw",
        "true",
        "try",
        "typeof",
        "unchecked",
        "uint",
        "ulong",
        "unsafe",
        "using",
        "var",
        "virtual",
        "volatile",
        "void",
        "where",
        "while",
        "yield",
    };

    void Start()
    {
        GameObject text1 = GameObject.Find("ManagerCS1");
        GameObject text2 = GameObject.Find("ManagerCS2");
        if (text1 != null)
        {
            csFile1 = text1.GetComponent<ExplorerCS>();
        }
        if (text2 != null)
        {
            csFile2 = text2.GetComponent<ExplorerCS>();
        }
        Button b = colorButton.GetComponent<Button>();
        b.onClick.AddListener(colorbuttonClicked);
    }

    public void colorbuttonClicked()
    {
        allisColored = csFile1.isColored && csFile2.isColored;
        if (allisColored == false)
        {
            colortext1();
            colortext2();
        }
    }

    private void colortext1()
    {
        if (!csFile1.eText.text.Contains("<color=blue>")) 
        {
            var edit = String.Join(@"[ ]+|[ \(\)\n]?", keywordsCS);
            var cs = "(" + edit + ")";
            var onelineComment = @"(//.+\n)";
            var curly = @"([\(\)])";
            var manyComments = new Regex(@"(/\*.*\*/)", RegexOptions.Singleline);
            csFile1.eText.text = Regex.Replace(csFile1.eText.text, cs, "<color=blue>$1</color>");
            csFile1.eText.text = Regex.Replace(csFile1.eText.text, curly, "<color=black>$1</color>");
            csFile1.eText.text = manyComments.Replace(csFile1.eText.text, "<color=green>$1</color>");
            csFile1.eText.text = Regex.Replace(csFile1.eText.text, onelineComment, "<color=green>$1</color>");
            csFile1.isColored = true;
        }
    }

    private void colortext2()
    {
        if (!csFile2.eText.text.Contains("<color=blue>"))
        {
            var edit = String.Join(@"[ ]+|[ \(\)\n]?", keywordsCS);
            var cs = "(" + edit + ")";
            var onelineComment = @"(//.+\n)";
            var curly = @"([\(\)])";
            var manyComments = new Regex(@"(/\*.*\*/)", RegexOptions.Singleline);
            csFile2.eText.text = Regex.Replace(csFile2.eText.text, cs, "<color=blue>$1</color>");
            csFile2.eText.text = Regex.Replace(csFile2.eText.text, curly, "<color=black>$1</color>");
            csFile2.eText.text = manyComments.Replace(csFile2.eText.text, "<color=green>$1</color>");
            csFile2.eText.text = Regex.Replace(csFile2.eText.text, onelineComment, "<color=green>$1</color>");
            csFile2.isColored = true;
        }
    }
}
