using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class fuck : MonoBehaviour
{
    public TextMeshProUGUI cheatCodeText;
    private bool konami = false;

    private List<string> _keyStrokeHistory;

    void Awake() {
        _keyStrokeHistory = new List<string>();
    }

    void Update() {
        KeyCode keyPressed = DetectKeyPressed();
        DeleteKeyStrokeToHistory();
        AddKeyStrokeToHistory(keyPressed.ToString());
        //keyStrokeText.text = "HISTORY: " + GetKeyStrokeHistory();
        if(Input.GetKeyDown(KeyCode.Delete)){
            ClearKeyStrokeHistory();
        }
        if(Input.GetKeyDown(KeyCode.Return) && GetKeyStrokeHistory().Equals("UpArrowUpArrowDownArrowDownArrowLeftArrowRightArrowLeftArrowRightArrowBA")) {
            ClearKeyStrokeHistory();
            konami = true; 
        }
        if (konami == true){
            cheatCodeText.text = "Cheats Enabled"; //+ GetKeyStrokeHistory(); <- if you want to show cheat code
        }
        if(Input.GetKeyDown(KeyCode.Return) && konami == true && GetKeyStrokeHistory().Equals("OMPRESENTS")){
            ClearKeyStrokeHistory();
            cheatCodeText.text = "Video Enabled???";
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            konami=false;
            }
    }

    private KeyCode DetectKeyPressed() {
        foreach(KeyCode key in Enum.GetValues(typeof(KeyCode))) {
            if(Input.GetKeyDown(key)) {
                return key;
            }
        }
        return KeyCode.None;
    }

    private void AddKeyStrokeToHistory(string keyStroke) {
        if(!keyStroke.Equals("None")&& !keyStroke.Equals("Backspace")&& !keyStroke.Equals("Mouse0") && !keyStroke.Equals("Escape") && !keyStroke.Equals("Mouse1")&&!keyStroke.Equals("Return")&&!keyStroke.Equals("Space")) {
            _keyStrokeHistory.Add(keyStroke);
            if(_keyStrokeHistory.Count > 10 /*&& konami == false <- Infinite text can show up*/) {
                _keyStrokeHistory.RemoveAt(0);
            }
        }
    }

    private string GetKeyStrokeHistory() {
        return String.Join("",_keyStrokeHistory.ToArray());
    }

    private void ClearKeyStrokeHistory() {
        _keyStrokeHistory.Clear();
    }

    private void DeleteKeyStrokeToHistory() {
        if(Input.GetKeyDown(KeyCode.Backspace) && _keyStrokeHistory.Count > 0){
            _keyStrokeHistory.RemoveAt(_keyStrokeHistory.Count - 1);
        }
    }
}
