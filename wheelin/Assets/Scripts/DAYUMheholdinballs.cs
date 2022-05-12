using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAYUMheholdinballs : MonoBehaviour
{
    public Pocketfulllomoney inv;
    
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


}
