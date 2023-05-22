using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private PickupSystem _pickupSystem;
    public ItemType ItemType;
    
    private bool _isPickedUp;
    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject != _pickupSystem.playerBody || _isPickedUp) return;
    }
}
