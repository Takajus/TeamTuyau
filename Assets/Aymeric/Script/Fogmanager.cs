using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogmanager : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("animationNumber", GameMaster.instance.animation_nb);
    }
}
