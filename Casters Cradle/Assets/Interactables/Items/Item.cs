using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/General Item", order = 0)]
public class Item : ScriptableObject
{
    [Header("General Settings")]
    public new string name;
    public Sprite icon;
    public ItemType itemType;
    public bool isStackable;
    public int amount;
}

public enum ItemType
{
    Null,
    Gold,
    SpellComponent,
    Spell
}
