using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class whathesayin : MonoBehaviour
{
    public string[] dialogue;
    public string Name;

    void Start()
    {
        if(Name == null) {
            Name = this.name;
        }
    }

    void Update()
    {
        
    }
}
