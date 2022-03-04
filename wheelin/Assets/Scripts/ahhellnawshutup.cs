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
    public TextMeshProUGUI facts;
    public string realname;
    public string[] word;


    public whathesayin talkscript;

    public float seelength;
    RaycastHit hit;

    bool start;

    void Start()
    {
        
    }


    void Update()
    {    
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawLine(ray.origin, hit.point);
        if(Physics.Raycast(ray, out hit, seelength)){
            var selection = hit.transform;
            if(selection.CompareTag("NPC")){
                talkscript = selection.GetComponent<whathesayin>();
                npc = selection.gameObject;
                realname = npc.name;
                names.text = realname;
                word = talkscript.dialogue;

                //COLOR EDIT
                names.color = new Color32(talkscript.R,talkscript.G,talkscript.B,255);

                facts.color = new Color32(talkscript.NameR,talkscript.NameG,talkscript.NameB,255);

                facts.text = word[talkscript.numinConv];
                if(Input.GetKeyDown(KeyCode.E)){
                    ui.SetActive(true);
                    start = true;
                }
                if(Input.GetKeyDown(KeyCode.Mouse0)&& talkscript.numinConv != talkscript.maxnuminConv-1 && start == true){
                    facts.text = word[talkscript.numinConv++];
            } else if(Input.GetKeyDown(KeyCode.Mouse0)&& talkscript.numinConv == talkscript.maxnuminConv-1){
                ui.SetActive(false);
                ResetTheTalk();
            }
            
        }
        } else {
            if(start == true){
                talkscript.numinConv = 0;
                start = false; ui.SetActive(false);
                }
    }
    }

        void ResetTheTalk(){
                talkscript.numinConv = 0;
                start = false;
        }

    }
