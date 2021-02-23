using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CompareTextsVB : MonoBehaviour
{
    ExplorerVB vbFile1;
    ExplorerVB vbFile2;
    Text textOP;
    void Start()
    {
        GameObject text1 = GameObject.Find("ManagerVB1");
        GameObject text2 = GameObject.Find("ManagerVB2");
        GameObject outputText = GameObject.Find("OutputTextVB");
        if (text1 != null)
        {
            vbFile1 = text1.GetComponent<ExplorerVB>();
        }
        if (text2 != null)
        {
            vbFile2 = text2.GetComponent<ExplorerVB>();
        }
        if (outputText != null)
        {
            textOP = outputText.GetComponent<Text>();
        }
    }

    void Update()
    {
        if (vbFile1.readText && vbFile2.readText)
        {
            fileAnalysis();
        }
    }

    private void fileAnalysis()
    {
        string fileName1 = vbFile1.fileExplorer.fileName, fileName2 = vbFile2.fileExplorer.fileName;
        FileInfo fileInfo1 = new FileInfo(fileName1);
        FileInfo fileInfo2 = new FileInfo(fileName2);

        textOP.text = "Byte info: \n<color=#333333>File1 length: " + fileInfo1.Length + " bytes" + "\nFile2 length: " + fileInfo2.Length + " bytes</color>";
        textOP.text += "\nCreation info: \n<color=#333333>File1 creation time: " + fileInfo1.CreationTime + "\nFile2 creation time: " + fileInfo2.CreationTime + "</color>";
        textOP.text += "\nLast access time info: \n<color=#333333>File1: " + fileInfo1.LastAccessTime + "\nFile2: " + fileInfo2.LastAccessTime + "</color>";
        textOP.text += "\nLast write time info: \n<color=#333333>File1: " + fileInfo1.LastWriteTime + "\nFile2: " + fileInfo2.LastWriteTime + "</color>";
        textOP.text += "\nIsReadOnly info: \n<color=#333333>File1: " + fileInfo1.IsReadOnly + "\nFile2: " + fileInfo2.IsReadOnly + "</color>";
    }
}
