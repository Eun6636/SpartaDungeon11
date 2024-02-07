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
    private ItemData curSlot;  //받아올 데이터
    private Outline outline;
    public GameObject equipTrue;


    public int index;

    void Awake()
    {
        outline = GetComponent<Outline>();
        
    }


    // 선택중이면 outline 컴포넌트 켜지게
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

    //클릭 핸들러
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

    

    //UI 리셋
    public void Clear()
    {
        curSlot = null;
        icon.gameObject.SetActive(false);
    }
}
