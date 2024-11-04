using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotTag {None, Slot1, Slot2, Slot3, Slot4, Slot5}

[CreateAssetMenu(menuName = "Scriptables Objects/Item")]
public class ItemSlots : ScriptableObject
{
    public Sprite sprite;
    public SlotTag itemTag;

    [Header("If the item can be Equipped")]
    public GameObject itemPrefab;
}