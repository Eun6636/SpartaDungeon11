using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        InvokeRepeating("RandomAnimation", 5, 7);
    }

    void Update()
    {
        
    }

    void RandomAnimation()
    {
        if(Random.Range(0,2) == 0)
        {
            animator.SetTrigger("GetHit");
        }
        else
        {
            animator.SetTrigger("Die");
        }
    }
}
