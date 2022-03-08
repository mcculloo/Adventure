using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funnyeyebrowguy : MonoBehaviour, IInteract
{
    int numhit = 0;
    //public delegate void TalkedTo();
    // public event TalkedTo OnComplete; event failure
    public GameObject rockman;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(){

        if(this.name == "monkeyrock"){
            numhit++;
            whathesayin talkscript = rockman.GetComponent<whathesayin>();
            if(numhit == 1){
                this.tag = "NPC";
                talkscript.dialNum=2;
                Debug.Log("dial num 2");
            }
        } else {        
            Destroy(this.gameObject);
            }
    }
}
