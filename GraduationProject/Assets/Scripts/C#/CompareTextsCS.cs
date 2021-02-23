using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CompareTextsCS : MonoBehaviour
{
    ExplorerCS csFile1;
    ExplorerCS csFile2;
    Text textOP;
    void Start()
    {
        GameObject text1 = GameObject.Find("ManagerCS1");
        GameObject text2 = GameObject.Find("ManagerCS2");
        GameObject outputText = GameObject.Find("OutputTextCS");
        if (text1 != null)
        {
            csFile1 = text1.GetComponent<ExplorerCS>();
        }
        if (text2 != null)
        {
            csFile2 = text2.GetComponent<ExplorerCS>();
        }
        if (outputText != null)
        {
            textOP = outputText.GetComponent<Text>();
        }
    }

    void Update()
    {
        if (csFile1.readText && csFile2.readText) {
            FileAnalysis();
        }
    }

    private void FileAnalysis()
    {
        string fileName1 = csFile1.fileExplorer.fileName, fileName2 = csFile2.fileExplorer.fileName;
        FileInfo fileInfo1 = new FileInfo(fileName1);
        FileInfo fileInfo2 = new FileInfo(fileName2);

        textOP.text = "Byte info: \n<color=#333333>File1 length: " + fileInfo1.Length + " bytes" + "\nFile2 length: " + fileInfo2.Length + " bytes</color>";
        textOP.text += "\nCreation info: \n<color=#333333>File1 creation time: " + fileInfo1.CreationTime  + "\nFile2 creation time: " + fileInfo2.CreationTime + "</color>";
        textOP.text += "\nLast access time info: \n<color=#333333>File1: " + fileInfo1.LastAccessTime + "\nFile2: " + fileInfo2.LastAccessTime + "</color>";
        textOP.text += "\nLast write time info: \n<color=#333333>File1: " + fileInfo1.LastWriteTime + "\nFile2: " + fileInfo2.LastWriteTime + "</color>";
        textOP.text += "\nIsReadOnly info: \n<color=#333333>File1: " + fileInfo1.IsReadOnly + "\nFile2: " + fileInfo2.IsReadOnly + "</color>";
    }
}
