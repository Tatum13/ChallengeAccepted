using System.Collections.Generic;
using UnityEngine;

public sealed class PickupSystem : MonoBehaviour
{
    public GameObject playerBody;
    
    private Dictionary<ItemType, int> _itemStorage = new Dictionary<ItemType, int>();
    
    public void AddItem(ItemPickup pickup)
    {
        if (_itemStorage.ContainsKey(pickup.ItemType)) _itemStorage[pickup.ItemType] += 1;
        else _itemStorage[pickup.ItemType] = 1;
    }

    public void DeleteItem(ItemPickup pickup)
    {
        if(_itemStorage[pickup.ItemType] == 0) return;
        _itemStorage[pickup.ItemType]--;
    }
}
