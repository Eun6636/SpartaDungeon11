using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{

    [Header("slot")]
    public Image icon;
    private ItemData curSlot;  //�޾ƿ� ������
    private Outline outline;
    public GameObject equipTrue;


    public int index;

    void Awake()
    {
        outline = GetComponent<Outline>();
        
    }


    // �������̸� outline ������Ʈ ������
    void Update()
    {
        if (Inventory.instance.selectedItemIndex == index&& curSlot !=null)
        {
            outline.enabled = true;
        }
        else
        {
            outline.enabled = false;
        }

        if (curSlot != null&& Inventory.instance.OnEUI(curSlot))
        {
            equipTrue.SetActive(true);
        }
        else
        {
            equipTrue.SetActive(false);
        }
    }

    //Ŭ�� �ڵ鷯
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Inventory.instance.Wear(curSlot);

        }
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Inventory.instance.SelectItem(index);
            Inventory.instance.OnInfo(curSlot);

        }
    }


    public void Set(ItemData slot)
    {
        curSlot = slot;
        icon.gameObject.SetActive(true);
        icon.sprite = slot.icon;

    }

    

    //UI ����
    public void Clear()
    {
        curSlot = null;
        icon.gameObject.SetActive(false);
    }
}
