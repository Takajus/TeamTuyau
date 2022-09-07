using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_movement2 : MonoBehaviour
{
    public Animator animator;

    private GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        gameObject.layer = 9;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("animationNumber", gm.animation_nb);
        if(gm.animation_nb > 2) {
            gameObject.layer = 10;
        } else { 
            gameObject.layer = 9;
        }
    }
}