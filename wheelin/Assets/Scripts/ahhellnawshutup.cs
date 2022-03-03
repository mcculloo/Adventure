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
    private Transform _selection;

    public bool resettalk = true;
    bool start;
    bool notlooking;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {    
        NotLooking();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawLine(ray.origin, hit.point);
        if(_selection != null){
            notlooking = true;
            resettalk = true;
            _selection = null;
        }
        if(Physics.Raycast(ray, out hit, seelength)){
            var selection = hit.transform;
            if(selection.CompareTag("NPC")){
                notlooking = false;
                resettalk = false;
                talkscript = selection.GetComponent<whathesayin>();
                npc = selection.gameObject;
                realname = npc.name;
                names.text = realname;
                word = talkscript.dialogue;
                facts.text = word[talkscript.numinConv];
                if(Input.GetKeyDown(KeyCode.E)){
                    ui.SetActive(true);
                    start = true;
                }
                if(Input.GetKeyDown(KeyCode.Mouse0)&& talkscript.numinConv != talkscript.maxnuminConv-1 && start == true){
                    facts.text = word[talkscript.numinConv++];
            } else if(Input.GetKeyDown(KeyCode.Mouse0)&& talkscript.numinConv == talkscript.maxnuminConv-1){
                ui.SetActive(false);
                resettalk = true;
                start = false;
            }
            _selection = selection;
            
        }
        } ResetTheTalk(); 
    }
              

        void ResetTheTalk(){
            if(resettalk == true){
                talkscript.numinConv = 0;
                start = false;
            }
        }

        void NotLooking(){
            if (notlooking == true){
                ui.SetActive(false);
            }
        }

    }
