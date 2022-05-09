using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("Item To Spawn")]
    [SerializeField] private Item _item;
    [SerializeField] private int _amount;

    private void Start()
    {
        Item itemToSpawn = Instantiate(_item);
        if (itemToSpawn.isStackable)
        {
            itemToSpawn.amount = _amount;
        }
        DropItem.SpawnItem(transform.position, itemToSpawn);
        Destroy(gameObject);
    }
}
