using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_movement : MonoBehaviour
{
    public Animator animator;
    
    private GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("animationNumber", gm.animation_nb);
    }
}
