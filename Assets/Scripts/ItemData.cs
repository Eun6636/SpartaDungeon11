using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor

}

public enum increaseType
{
    DFS,
    ATK,
    Health,
    CR
}

[System.Serializable]
public class ItemDataConsumable
{
    public increaseType type; //어떤 타입에 어떤 능력치를 줄건지
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string Name;
    public string description;
    public ItemType type;
    public Sprite icon;

    //[Header("Stacking")]
    //public bool canStack;  //존재 유무
    //public int maxStackAmount;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;


}