using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoInventory : MonoBehaviour
{
        public Pocketfulllomoney inv;

        public List<TextMeshProUGUI> slots;

        void FixedUpdate(){
            for(int i = 0; i < inv.Inventory.Count; i++){
                slots[i].text = inv.Inventory[i].item.name;
            }
        }

}
