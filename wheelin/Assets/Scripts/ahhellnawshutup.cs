using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ahhellnawshutup : MonoBehaviour
{
    public GameObject npc;
    public Text name;
    public string realname;
    public string[] word;

    public whathesayin worsd;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col){
        npc = col.gameObject;
        realname = npc.name;
        //name.text = realname;
        word = worsd.dialogue;
    }

}
