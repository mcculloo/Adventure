using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAYUMheholdinballs : MonoBehaviour
{
    public Pocketfulllomoney inv;
    public GameObject QuestBook;
    public GameObject InventoryBook;
    
    public bool open;
    private bool upButton;

    void Update(){
        OpenBook();
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Item")){
            var item = col.GetComponent<Brothisgettingold>();
            inv.AddItem(item.item, 1);
            Destroy(col.gameObject);
    } 
    }

    private void OnApplicationQuit(){
        inv.Inventory.Clear();
    }

    void OpenBook(){
        if(Input.GetKeyDown(KeyCode.Q) && open && !upButton) {
            QuestBook.SetActive(false);
            InventoryBook.SetActive(false);
            open = false;
            upButton = true;
            Debug.Log("closed");
        } 
        if(Input.GetKeyUp(KeyCode.Q)&& upButton){
            upButton = false;
            Debug.Log("button went up");
        }

        if(Input.GetKeyDown(KeyCode.Q) && !open && !upButton) {
            QuestBook.SetActive(true);
            InventoryBook.SetActive(true);
            open = true;
            upButton = true;
            Debug.Log("opened");
        } 
    }
}
