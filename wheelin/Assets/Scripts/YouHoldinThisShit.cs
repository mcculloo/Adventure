using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "ScriptableObjects/Item")]
public class YouHoldinThisShit : ScriptableObject
{
    public int ItemID;
    public GameObject prefab;
}
