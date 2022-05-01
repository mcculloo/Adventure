using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moveyouhoe : MonoBehaviour
{
[SerializeField]
Transform othertele;
public GameObject playa;
twoballsinmymouth movethishoe;
public float TeleportTimer;
public float SmoothToStop;
public float AvailableNextTeleport;

Vector2 currentDirVelocity = Vector2.zero;

public bool moveToOtherScene;
public string sceneToMoveTo;

void Start(){
    movethishoe = playa.GetComponent<twoballsinmymouth>();
}

void OnTriggerEnter(Collider col){
    if(col.gameObject.CompareTag("Player") && movethishoe.canTele){
        movethishoe.canTele = false;
        StartCoroutine(teleportpls(TeleportTimer, SmoothToStop));
    } 

}

    
    private IEnumerator teleportpls(float timer, float stopSpeed){
        movethishoe.controller.enabled = false;
        movethishoe.rb.velocity = movethishoe.rb.velocity * stopSpeed;
        yield return new WaitForSeconds(timer + stopSpeed);

        if(!moveToOtherScene){
        playa.transform.position = othertele.transform.position;
        movethishoe.controller.enabled = true;
        yield return new WaitForSeconds(AvailableNextTeleport);
        movethishoe.canTele = true;
        }
        
        if(moveToOtherScene){
            SceneManager.LoadScene(sceneToMoveTo);
        }
    }

}
