using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvantoryController : MonoBehaviour
{
    public GameObject buttonActive;
    public GameObject player;
    public GameObject Ac;
    public Transform pos;
    //public Animation Ac_ani;

    Vector3 playerPos;
    bool Player_move;

    public AchievementController ac;

    private void Start()
    {
        
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }

    private void Update()
    {
        if (Player_move)
        {
            player.transform.Translate(Vector2.right * -Time.deltaTime *6, Space.World);
            if (player.transform.position.x <= pos.position.x)
            {
                Player_move = false;
                player.transform.position = new Vector3(pos.position.x, playerPos.y, playerPos.z);
            }

        }


        //if (!Player_move)
        //{
        //    player.gameObject.transform.position = playerPos.position;
        //}

    }
    public void OnInventory()
    {
        buttonActive.SetActive(false);
        gameObject.SetActive(true);
        Player_move = true;
        ac.animator.SetTrigger("False");
    }

    public void ResetAni()
    {

        player.transform.position = playerPos;
        Ac.SetActive(true);

        buttonActive.SetActive(true);
        gameObject.SetActive(false);
    }


}
