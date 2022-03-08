using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class whathesayin : MonoBehaviour
{
    public List<string> dialogue;
    [HideInInspector]
    public int numinConv;
    [HideInInspector]
    public int maxnuminConv;
    public int dialNum;
    public bool finishedTalking;

    [Header("Text Color")]
    [Range(0f, 255f)]
    public byte R;
    [Range(0f, 255f)]
    public byte G;
    [Range(0f, 255f)]
    public byte B;

    [Header("Name Color")]
    [Range(0f, 255f)]
    public byte NameR;
    [Range(0f, 255f)]
    public byte NameG;
    [Range(0f, 255f)]
    public byte NameB;

    [HideInInspector]
    public GameObject textObj;

    public List<MyClass> AllDialogue;

    void Start()
    {
        dialNum = 0;
        numinConv = 0;
        dialogue = AllDialogue[dialNum].DialogueOptions;
        maxnuminConv = dialogue.Count;
        textObj = this.transform.Find("text").gameObject;
    }

    void Update()
    {
        if(finishedTalking && dialNum < 1){
            dialNum = 1;
            dialogue = AllDialogue[dialNum].DialogueOptions;
            maxnuminConv = dialogue.Count;
            Debug.Log("TASDA");
        }
        if(dialNum == 2 && finishedTalking){
            dialogue = AllDialogue[dialNum].DialogueOptions;
            maxnuminConv = dialogue.Count;
        }

    }
}

[System.Serializable]
public class MyClass {

public List<string> DialogueOptions;

}
