using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.VisualBasic;
using SmartDLL;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ExplorerCS : MonoBehaviour
{
    public Text eText;
    public Button openExplorerButton;
    public Button formatButton;

    public SmartFileExplorer fileExplorer = new SmartFileExplorer();

    public bool readText = false;
    private bool isFormatted = false;
    public bool isColored = false;

    public bool result;
    private void OnEnable()
    {
        openExplorerButton.onClick.AddListener(delegate { showExplorer(); });
    }

    void Start()
    {
        Button b = formatButton.GetComponent<Button>();
        b.onClick.AddListener(buttonClicked);
    }
    
    public void buttonClicked()
    {
        if (!isColored)
        {
            formatText();
            isFormatted = true;
        }
    }

    void Update()
    {
        result = fileExplorer.resultOK && readText; 
        if (result)
        {
            readTextFile(fileExplorer.fileName);
            fileExplorer.resultOK = false;
            isColored = false;
        }
        if (isFormatted)
        {
            result = false;
            isFormatted = false;
        }
    }
    
    void showExplorer()
    {
        string initialDir = @"C:\";
        bool restoreDir = true;
        string title = "Open File";
        string defExt = "cs";
        string filter = "C# files (*.cs)|*.cs";

        fileExplorer.OpenExplorer(initialDir, restoreDir, title, defExt, filter);
        readText = true;
    }

    void readTextFile(string path)
    {
        eText.text = File.ReadAllText(path);
    }

    private void formatText()
    {
        if (!isColored)
            eText.text = arrangeUsingRoslyn(eText.text);
    }
    
    public string arrangeUsingRoslyn(string codeCS)
    {
        var tree = CSharpSyntaxTree.ParseText(codeCS);
        var root = tree.GetRoot().NormalizeWhitespace();
        var ret = root.ToFullString();
        return ret;
    }
}
