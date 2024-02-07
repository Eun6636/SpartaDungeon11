using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]
public class Player
{
    public int DFS;
    public int ATK;
    public int HP;
    public int CR;

}

public class GameManager : MonoBehaviour
{
    int curATK;
    int curDFS;
    int curHP;
    int curCR;

    [SerializeField] private Player playerStatus;


    [Header("StatusUI")]
    public TextMeshProUGUI ATK;
    public TextMeshProUGUI DFS;
    public TextMeshProUGUI HP;
    public TextMeshProUGUI CR;


    public static GameManager Instanse;

    private void Awake()
    {
        Instanse = this;
    }

    private void Start()
    {
        curATK = playerStatus.ATK;
        curDFS = playerStatus.DFS;
        curHP = playerStatus.HP;
        curCR = playerStatus.CR;

        ResrtStatUI();
    }


    //스테이터스 증감
    public void StatusIncreaseOrDecrease(int A, int D, int H, int C)
    {
        curATK += A;
        curDFS += D;
        curHP += H;
        curCR += D;

        ResrtStatUI();
    }

    //UI 텍스트 초기화
    void ResrtStatUI()
    {
        ATK.text = curATK.ToString();
        DFS.text = curDFS.ToString();
        HP.text = curHP.ToString();
        CR.text = curCR.ToString();
    }
}
