using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inevtory Data", menuName = "ScriptableObjects/Inventory")]
public class Pocketfulllomoney : ScriptableObject
{

    public List<InventorySlot> Inventory;


    public void AddItem(YouHoldinThisShit _item, int _amount){
        bool hasItem = false;
        for (int i = 0; i<Inventory.Count; i++){
            if(Inventory[i].item == _item){
                Inventory[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if(!hasItem){
            Inventory.Add(new InventorySlot(_item, _amount));
        }
    }

}

[System.Serializable]
public class InventorySlot{

    public YouHoldinThisShit item;
    public int amount;

    public InventorySlot(YouHoldinThisShit _item, int _amount){
        amount = _amount;
        item = _item;
    }

    public void AddAmount(int _newamount){
        amount += _newamount;
    }
}
