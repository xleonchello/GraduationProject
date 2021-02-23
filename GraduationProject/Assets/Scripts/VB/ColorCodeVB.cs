using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ColorCodeVB : MonoBehaviour
{
    ExplorerVB vbFile1;
    ExplorerVB vbFile2;
    public Button colorButton;
    public bool allisColored = false;
    public List<string> keywordsVB = new List<string>()
    {
        "AddHandler",
        "AddressOf",
        "Alias",
        "And",
        "AndAlso",
        "As",
        "Boolean",
        "ByRef",
        "Byte",
        "ByVal",
        "Call",
        "Case",
        "Catch",
        "CBool",
        "CByte",
        "CChar",
        "CDate",
        "CDbl",
        "CDec",
        "Char",
        "CInt",
        "Class",
        "CLng",
        "CObj",
        "Const",
        "Continue",
        "CSByte",
        "CShort",
        "CSng",
        "CStr",
        "CType",
        "CUInt",
        "CULng",
        "CUShort",
        "Date",
        "Decimal",
        "Declare",
        "Default",
        "Delegate",
        "Dim",
        "DirectCast",
        "Do",
        "Double",
        "Each",
        "Else",
        "ElseIf",
        "End",
        "EndIf",
        "Enum",
        "Erase",
        "Error",
        "Event",
        "Exit",
        "False",
        "Finally",
        "For",
        "Friend",
        "Function",
        "Get",
        "GetType",
        "GetXMLNamespace",
        "Global",
        "GoSub",
        "GoTo",
        "Handles",
        "If",
        "Implements",
        "Imports In",
        "Inherits",
        "Integer",
        "Interface",
        "Is",
        "IsNot",
        "Let",
        "Lib",
        "Like",
        "Long",
        "Loop",
        "Me",
        "Mod",
        "Module",
        "MustInherit",
        "MustOverride",
        "MyBase",
        "MyClass",
        "Namespace",
        "Narrowing",
        "New",
        "Next",
        "Not",
        "Nothing",
        "NotInheritable",
        "NotOverridable",
        "Object",
        "Of",
        "On",
        "Operator",
        "Option",
        "Optional",
        "Or",
        "OrElse",
        "Out",
        "Overloads",
        "Overridable",
        "Overrides",
        "ParamArray",
        "Partial",
        "Private",
        "Property",
        "Protected",
        "Public",
        "RaiseEvent",
        "ReadOnly",
        "ReDim",
        "REM",
        "RemoveHandler",
        "Resume",
        "Return",
        "SByte",
        "Select",
        "Set",
        "Shadows",
        "Shared",
        "Short",
        "Single",
        "Static",
        "Step",
        "Stop",
        "String",
        "Structure",
        "Sub",
        "SyncLock",
        "Then",
        "Throw",
        "To",
        "True",
        "Try",
        "TryCast",
        "TypeOf",
        "UInteger",
        "ULong",
        "UShort",
        "Using",
        "Variant",
        "Wend",
        "When",
        "While",
        "Widening",
        "With",
        "WithEvents",
        "WriteOnly",
        "Xor",
    };

    void Start()
    {
        GameObject text1 = GameObject.Find("ManagerVB1");
        GameObject text2 = GameObject.Find("ManagerVB2");
        if (text1 != null)
        {
            vbFile1 = text1.GetComponent<ExplorerVB>();
        }
        if (text2 != null)
        {
            vbFile2 = text2.GetComponent<ExplorerVB>();
        }
        Button b = colorButton.GetComponent<Button>();
        b.onClick.AddListener(colorbuttonClicked);
    }

    public void colorbuttonClicked()
    {
        allisColored = vbFile1.isColored && vbFile2.isColored;
        if (allisColored == false)
        {
            Colortext1();
            Colortext2();
        }
    }

    private void Colortext1()
    {
        if (!vbFile1.eText.text.Contains("<color=blue>"))
        {
            var edit = String.Join(@"[ ]+|[ \(\)\n]?", keywordsVB);
            var vb = "(" + edit + ")";
            var onelineComment = @"('.+\n)";
            var curly = @"([\(\)])";
            vbFile1.eText.text = Regex.Replace(vbFile1.eText.text, vb, "<color=blue>$1</color>");
            vbFile1.eText.text = Regex.Replace(vbFile1.eText.text, curly, "<color=black>$1</color>");
            vbFile1.eText.text = Regex.Replace(vbFile1.eText.text, onelineComment, "<color=green>$1</color>");
            vbFile1.isColored = true;
        }
    }

    private void Colortext2()
    {
        if (!vbFile2.eText.text.Contains("<color=blue>"))
        {
            var edit = String.Join(@"[ ]+|[ \(\)\n]?", keywordsVB);
            var vb = "(" + edit + ")";
            var onelineComment = @"('.+\n)";
            var curly = @"([\(\)])";;
            vbFile2.eText.text = Regex.Replace(vbFile2.eText.text, vb, "<color=blue>$1</color>");
            vbFile2.eText.text = Regex.Replace(vbFile2.eText.text, curly, "<color=black>$1</color>");
            vbFile2.eText.text = Regex.Replace(vbFile2.eText.text, onelineComment, "<color=green>$1</color>");
            vbFile2.isColored = true;
        }
    }
}
