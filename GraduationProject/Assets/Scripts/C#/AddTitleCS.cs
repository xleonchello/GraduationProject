using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AddTitleCS : MonoBehaviour
{
    ExplorerCS csFile1;
    ExplorerCS csFile2;
    Text fileName1;
    Text fileName2;

    void Start()
    {
        GameObject title1 = GameObject.Find("TitleCS1");
        GameObject title2 = GameObject.Find("TitleCS2");
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
        if (csFile1.result)
            titleEdit1();
        if (csFile2.result)
            titleEdit2();
    }

    private void titleEdit1()
    {
        string nameOfFile1 = csFile1.fileExplorer.fileName;
        FileInfo fileInfo1 = new FileInfo(nameOfFile1);
        fileName1.text = "<b>File: </b>" + fileInfo1.FullName;
    }
    private void titleEdit2()
    {
        string nameOfFile2 = csFile2.fileExplorer.fileName;
        FileInfo fileInfo2 = new FileInfo(nameOfFile2);
        fileName2.text = "<b>File: </b>" + fileInfo2.FullName;
    }
}
