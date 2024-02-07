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
    public increaseType type; //� Ÿ�Կ� � �ɷ�ġ�� �ٰ���
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
    //public bool canStack;  //���� ����
    //public int maxStackAmount;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;


}