using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AddTitleVB : MonoBehaviour
{
    ExplorerVB vbFile1;
    ExplorerVB vbFile2;
    Text fileName1;
    Text fileName2;

    void Start()
    {
        GameObject title1 = GameObject.Find("TitleVB1");
        GameObject title2 = GameObject.Find("TitleVB2");
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
        if (title1 != null)
        {
            fileName1 = title1.GetComponent<Text>();
        }
        if (title2 != null)
        {
            fileName2 = title2.GetComponent<Text>();
        }
    }

    void Update()
    {
        if (vbFile1.result)
            titleEdit1();
        if (vbFile2.result)
            titleEdit2();
    }

    private void titleEdit1()
    {
        string nameOfFile1 = vbFile1.fileExplorer.fileName;
        FileInfo fileInfo1 = new FileInfo(nameOfFile1);
        fileName1.text = "<b>File: </b>" + fileInfo1.FullName;
    }
    private void titleEdit2()
    {
        string nameOfFile2 = vbFile2.fileExplorer.fileName;
        FileInfo fileInfo2 = new FileInfo(nameOfFile2);
        fileName2.text = "<b>File: </b>" + fileInfo2.FullName;
    }
}
