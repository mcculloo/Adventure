using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class whathesayin : MonoBehaviour
{
    public string[] dialogue;
    public string Name;
    public int numinConv;
    public int maxnuminConv;

    void Start()
    {
        if(Name == null) {
            Name = this.name;
        }
        numinConv = 0;
        maxnuminConv = dialogue.Length;
    }

    void Update()
    {
        
    }
}
