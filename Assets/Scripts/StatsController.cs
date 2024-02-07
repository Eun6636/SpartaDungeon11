using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    public GameObject button;

    public void OnStats()
    {
        gameObject.SetActive(true);
        button.SetActive(false);
    }

    public void ActiveFalse()
    {
        gameObject.SetActive(false);
        button.SetActive(true);
    }

}
