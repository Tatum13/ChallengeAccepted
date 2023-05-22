using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    public GameObject playerBody;
    
    private Dictionary<ItemType, int> _itemStorage = new Dictionary<ItemType, int>();

    private bool AddItem()
    {
        return true;
    }
}
