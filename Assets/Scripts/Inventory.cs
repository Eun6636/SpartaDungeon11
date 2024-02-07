using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InfoBGController info;
    public Slot[] uiSlots;   //UI�� ������ ����
    public ItemData[] slots;   //���� ������ �ִ� ����

    private ItemData selectedItem;
    public int selectedItemIndex; //���� ���� �ִ� �ε���

    public static Inventory instance; //�̱���
    void Awake()
    {
        instance = this;
        // ���⼭ �÷��̾� ���� �������ͽ� ����;��ҵ�
    }

    private void Start()
    {
        //slots = new ItemData[uiSlots.Length];

        for (int i = 0; i < slots.Length; i++)  //���� �ʱ�ȭ
        {
            uiSlots[i].index = i;

            //UI �����ܱ���
            if(slots[i] != null) uiSlots[i].Set(slots[i]);
        }

        //ClearSeletecItemWindow();
    }


    //�������� �������� ����
    public void SelectItem(int index)
    {
        if (slots[index] == null) //�������� ������ �׳� ��ȯ
            return;


        selectedItem = slots[index];
        selectedItemIndex = index;

        // ������Ʈ �ۺ����� �޾ƿͼ� ������
    }

    public void OnInfo(ItemData itemData)
    {
        info.Set(itemData);
    }

    public void AddItem(ItemData item)
    {
        slots[slots.Length] = item;
    }

    //����
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
        //�ٽ� �ʱ�ȭ
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null)
                uiSlots[i].Set(slots[i]);
            else
                uiSlots[i].Clear();
        }
    }

}
