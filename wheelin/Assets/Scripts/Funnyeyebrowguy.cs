using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Funnyeyebrowguy : MonoBehaviour, IInteract, ITalkEvent
{
    int numhit = 0;
    public GameObject rockman;
    public GameObject player;
    public ParticleSystem rockEffect;

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
                StartCoroutine(anime(2f, animation));
                this.tag = "NPC";
                talkscript.dialNum=2;
                animation.SetBool("MonkeyUp", true);
            }
        } else {        
            Destroy(this.gameObject);
            rockEffect.transform.position = this.transform.position;
            Instantiate(rockEffect, this.transform.position, Quaternion.Euler(-90f,0f,0f));
            }
    }

    private IEnumerator anime(float timer, Animator hue){
        yield return new WaitForSeconds(timer);
        hue.enabled = false;
    }

    public void TalkEvent(){
            
    }
}
