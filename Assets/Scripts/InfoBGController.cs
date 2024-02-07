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


    //착용
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

    //설명창 세팅
    public void Set(ItemData itemData)
    {

        ActiveTrue();
        InfoIcon.sprite = itemData.icon;
        Name.text = itemData.Name;
        Infodescription.text = itemData.description;
    }

    //UI E 표시 키기
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


    //스텟 초기화
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
                    // DFS 변수 초기화
                    A = (int)consumable.value; // 예시로 value 값을 int로 변환하여 초기화
                    break;
                case increaseType.ATK:
                    // ATK 변수 초기화
                    D = (int)consumable.value;
                    break;
                case increaseType.Health:
                    // Health 변수 초기화
                    H = (int)consumable.value;
                    break;
                case increaseType.CR:
                    // CR 변수 초기화
                    C = (int)consumable.value;
                    break;
            }
        }
        if(b) //스테이터스 추가
        {
            GameManager.Instanse.StatusIncreaseOrDecrease(A, D, H, C);
        }
        else
        {
            GameManager.Instanse.StatusIncreaseOrDecrease(-A, -D, -H, -C);
        }
    }
}
