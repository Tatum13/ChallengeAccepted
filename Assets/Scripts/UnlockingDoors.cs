using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingDoors : MonoBehaviour
{
    public ItemType itemType;
    public DoorTypes doorTypes;

    private PickupSystem _pickupSystem;

    public void OnTriggerEnter(Collider collider) //of moet het een OnCollision zijn?
    {
        if(collider != _pickupSystem.playerBody) return;
        
        //kijken naar welke itemType er nodig is om de deur te unlocken.
        /*
        if (doorTypes != null)
        {
            switch (itemType)
            {
                case ItemType.keyYellow:
                    Debug.Log("yellow");
                    break;
                case ItemType.keyBlue:
                    Debug.Log("blue");
                    break;
                case ItemType.keyGreen:
                    Debug.Log("green");
                    break;
                case ItemType.keyPurple:
                    Debug.Log("purple");
                    break;
            }
        }
        */
        //_pickupSystem.DeleteItem();
        Destroy(gameObject);
    }
    
}
