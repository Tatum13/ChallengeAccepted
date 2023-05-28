using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private PickupSystem pickupSystem;
    [field: SerializeField] public ItemType ItemType {get; private set;}

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject != pickupSystem.playerBody) return;
        pickupSystem.AddItem(this);
        Destroy(gameObject);
    }
}
