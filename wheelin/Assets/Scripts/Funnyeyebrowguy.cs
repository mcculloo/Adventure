using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Funnyeyebrowguy : MonoBehaviour, IInteract, ITalkEvent
{
    int numhit = 0;
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
            Animator animation = gameObject.GetComponent<Animator>();
            if(numhit == 2){
                this.tag = "NPC";
                talkscript.dialNum=2;
                animation.SetBool("MonkeyUp", true);
                float time = animation.GetCurrentAnimatorStateInfo(0).length;
                StartCoroutine(anime(time, animation));
            }
        } else {        
            Destroy(this.gameObject);
            }
    }

    private IEnumerator anime(float timer, Animator hue){
        yield return new WaitForSeconds(timer);
        hue.enabled = false;
    }

    public void TalkEvent(){
            
    }
}
