using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InfoBGController info;
    public Slot[] uiSlots;   //UI에 보여줄 슬롯
    public ItemData[] slots;   //내가 가지고 있는 슬롯

    private ItemData selectedItem;
    public int selectedItemIndex; //지금 차고 있는 인덱스

    public static Inventory instance; //싱글톤
    void Awake()
    {
        instance = this;
        // 여기서 플레이어 스탯 스테이터스 갖고와야할듯
    }

    private void Start()
    {
        //slots = new ItemData[uiSlots.Length];

        for (int i = 0; i < slots.Length; i++)  //슬롯 초기화
        {
            uiSlots[i].index = i;

            //UI 아이콘까지
            if(slots[i] != null) uiSlots[i].Set(slots[i]);
        }

        //ClearSeletecItemWindow();
    }


    //아이템을 눌렀을때 선택
    public void SelectItem(int index)
    {
        if (slots[index] == null) //아이템이 없으면 그냥 반환
            return;


        selectedItem = slots[index];
        selectedItemIndex = index;

        // 오브젝트 퍼블릭으로 받아와서 가져옴
    }

    public void OnInfo(ItemData itemData)
    {
        info.Set(itemData);
    }

    public void AddItem(ItemData item)
    {
        slots[slots.Length] = item;
    }

    //착용
    public void Wear(ItemData itemData)
    {
        info.wear(itemData);
    }

    public bool OnEUI(ItemData itemData)
    {
        if (info.GetEquipData(itemData)) return true;
        else return false;
    }

    void UpdateUI()
    {
        //다시 초기화
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null)
                uiSlots[i].Set(slots[i]);
            else
                uiSlots[i].Clear();
        }
    }

}
