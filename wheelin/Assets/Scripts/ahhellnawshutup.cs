using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ahhellnawshutup : MonoBehaviour
{
    public GameObject npc;
    public GameObject ui;
    public TextMeshProUGUI names;
    public string realname;
    public string[] word;


    public whathesayin talkscript;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col){
        talkscript = col.GetComponent<whathesayin>();
        npc = col.gameObject;
        realname = npc.name;
        names.text = realname;
        word = talkscript.dialogue;
    }

}
