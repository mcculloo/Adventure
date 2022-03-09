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
    public List<string> word;
    public GameObject textToAwake;
    public float textSpeed;


    public whathesayin talkscript;

    public float seelength;
    RaycastHit hit;

    bool start;

    public float turnSpeed;
    private bool turning;
    private float r_turnSpeed;
    private bool doneT = true;

    void Awake()
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
                textToAwake = talkscript.textObj;
                if(!start){
                    textToAwake.SetActive(true);
                } 

                //COLOR EDIT
                names.color = new Color32(talkscript.R,talkscript.G,talkscript.B,255);

                facts.color = new Color32(talkscript.NameR,talkscript.NameG,talkscript.NameB,255);

                
                if(Input.GetKeyDown(KeyCode.E)&& start == false){
                    turning = true;
                    ui.SetActive(true);
                    start = true;
                    StartCoroutine(TypeLine());
                }
                if(Input.GetKeyDown(KeyCode.Mouse0)&& talkscript.numinConv != talkscript.maxnuminConv-1 && start == true){
                    if(facts.text == word[talkscript.numinConv]){
                        StopAllCoroutines();
                        talkscript.numinConv++;
                        StartCoroutine(TypeLine());
                    } else {
                        StopAllCoroutines();
                        facts.text = word[talkscript.numinConv];
                    }
            } else if(Input.GetKeyDown(KeyCode.Mouse0)&& talkscript.numinConv == talkscript.maxnuminConv-1){
                if(facts.text != word[talkscript.numinConv]){
                    StopAllCoroutines();
                    facts.text = word[talkscript.numinConv];
                } else {
                turning = false;
                ui.SetActive(false);
                talkscript.finishedTalking = true;
                ResetTheTalk();
                }

            }
            
        }
        } else {    
            turning = false;    
            if(textToAwake!=null) {
            textToAwake.SetActive(false);
        }
            if(start == true){
                talkscript.numinConv = 0;
                start = false; ui.SetActive(false);
                textToAwake.SetActive(false);
                }
    }
    if(turning || !doneT){
        TurnNPC();
    } 
    }


        void ResetTheTalk(){
                StopAllCoroutines();
                textToAwake.SetActive(false);
                talkscript.numinConv = 0;
                start = false;
                facts.text = string.Empty;
        }

        IEnumerator TypeLine(){
            textToAwake.SetActive(false);
            facts.text = string.Empty;
            foreach(char c in word[talkscript.numinConv].ToCharArray()){
                facts.text+= c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        void TurnNPC(){
            Vector3 TargetLook = new Vector3(this.transform.position.x, npc.transform.position.y, this.transform.position.z);
            Quaternion lookAtLoc = Quaternion.LookRotation(TargetLook - npc.transform.position);
            npc.transform.rotation = Quaternion.Lerp(npc.transform.rotation, lookAtLoc, Time.deltaTime * turnSpeed);
            
        }

    }
