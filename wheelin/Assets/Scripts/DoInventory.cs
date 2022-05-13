using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class DoInventory : MonoBehaviour
{
        public Pocketfulllomoney inv;

        public List<TextMeshProUGUI> slots;
        public List<GameObject> slotButtons;

        public GameObject descPage;
        public GameObject QuestBook;
        public GameObject InventoryBook;

        public bool open;
        private bool upButton;

        private TextMeshProUGUI[] descName;

        public int invNum = -1;
        public Transform handSpace;

        void Update(){
        OpenBook();
    }

        void FixedUpdate(){
            for(int i = 0; i < inv.Inventory.Count; i++){
                slots[i].text = inv.Inventory[i].item.name;
            }
            if(open){
                for(int i = 0; i < inv.Inventory.Count; i++){
                    slotButtons[i].SetActive(true);
                    slots[i].enabled = true;
            }
            }
        }
        
        public void onButtonClick(){
            descPage.SetActive(true);
            for(int i = 0; i < inv.Inventory.Count; i++){
                    if(slotButtons[i] == EventSystem.current.currentSelectedGameObject){
                    invNum = i;
                    descName = descPage.GetComponentsInChildren<TextMeshProUGUI>();
                    descName[0].text = inv.Inventory[i].item.name;
                    descName[1].text = inv.Inventory[i].item.desc;
                    }
                    
            }
        }

        public void onEquip(){
            int newitemID = -1;
            for(int i = 0; i < inv.Inventory.Count; i++){
                if(i == invNum){
                    if(newitemID != inv.Inventory[i].item.ItemID){
                    Instantiate(inv.Inventory[i].item.prefab, handSpace);
                    Debug.Log("spawned " + inv.Inventory[i].item.name);
                    newitemID = inv.Inventory[i].item.ItemID;
                    Debug.Log(newitemID);
                    Debug.Log(inv.Inventory[i].item.ItemID);
                    } else {
                    Debug.Log("same");
                    break;
                    }
                    
                }
            }
        }

        void OpenBook(){
        if(Input.GetKeyDown(KeyCode.Q) && open && !upButton) {
            Cursor.lockState = CursorLockMode.Locked;
            for(int i = 0; i < inv.Inventory.Count; i++){
                slotButtons[i].SetActive(false);
                slots[i].enabled = false;
            }
            QuestBook.SetActive(false);
            InventoryBook.SetActive(false);
            descPage.SetActive(false);
            open = false;
            upButton = true;
        } 
        if(Input.GetKeyUp(KeyCode.Q)&& upButton){
            upButton = false;
        }

        if(Input.GetKeyDown(KeyCode.Q) && !open && !upButton) {
            Cursor.lockState = CursorLockMode.None;
            QuestBook.SetActive(true);
            InventoryBook.SetActive(true);
            open = true;
            upButton = true;
        } 
    }

}
