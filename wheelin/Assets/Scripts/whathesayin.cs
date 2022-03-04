using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class whathesayin : MonoBehaviour
{
    public string[] dialogue;
    [HideInInspector]
    public int numinConv;
    [HideInInspector]
    public int maxnuminConv;

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


    void Start()
    {
        numinConv = 0;
        maxnuminConv = dialogue.Length;
    }

    void Update()
    {
        
    }
}
