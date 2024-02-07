using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoBGController : MonoBehaviour
{

    [Header("Info")]
    public Image InfoIcon;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Infodescription;

    [Header("Wear")]
    public Image Armor;
    public Image Wepon;

    private ItemData curArmor;
    private ItemData curWepon;

    float falseTime = 4;


    void Update()
    {
        if(falseTime >4)
        {
            falseTime = 4;
        }

        if(gameObject.activeSelf)
        {
            if (falseTime < 0)
            {
                ActiveFalse();
            }
            else
            {
                falseTime -= Time.deltaTime;
            }
        }
        
        
    }


    //����
    public void wear(ItemData item)
    {


        if(item.type == ItemType.Armor)
        {
            if(curArmor != null) GetItemStatue(curArmor, false);

            curArmor = item;
            Armor.sprite = curArmor.icon;
            GetItemStatue(curArmor, true);
        }
        if(item.type == ItemType.Weapon)
        {
            if (curWepon != null) GetItemStatue(curWepon, false);
            curWepon = item;
            Wepon.sprite = curWepon.icon;
            GetItemStatue(curWepon, true);
        }
    }

    //����â ����
    public void Set(ItemData itemData)
    {

        ActiveTrue();
        InfoIcon.sprite = itemData.icon;
        Name.text = itemData.Name;
        Infodescription.text = itemData.description;
    }

    //UI E ǥ�� Ű��
    public bool GetEquipData(ItemData item)
    {
        if(item == curArmor || item ==curWepon) return true;
        else return false;

    }


    void ActiveFalse()
    {
        gameObject.SetActive(false);
    }
    void ActiveTrue()
    {
        gameObject.SetActive(true);
        falseTime += 4;
    }


    //���� �ʱ�ȭ
    void GetItemStatue(ItemData item, bool b)
    {
        int A = 0;
        int D = 0;
        int H = 0;
        int C = 0;

        foreach (ItemDataConsumable consumable in item.consumables)
        {
            switch (consumable.type)
            {
                case increaseType.DFS:
                    // DFS ���� �ʱ�ȭ
                    A = (int)consumable.value; // ���÷� value ���� int�� ��ȯ�Ͽ� �ʱ�ȭ
                    break;
                case increaseType.ATK:
                    // ATK ���� �ʱ�ȭ
                    D = (int)consumable.value;
                    break;
                case increaseType.Health:
                    // Health ���� �ʱ�ȭ
                    H = (int)consumable.value;
                    break;
                case increaseType.CR:
                    // CR ���� �ʱ�ȭ
                    C = (int)consumable.value;
                    break;
            }
        }
        if(b) //�������ͽ� �߰�
        {
            GameManager.Instanse.StatusIncreaseOrDecrease(A, D, H, C);
        }
        else
        {
            GameManager.Instanse.StatusIncreaseOrDecrease(-A, -D, -H, -C);
        }
    }
}
