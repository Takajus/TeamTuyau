using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide_Plateform : MonoBehaviour
{
    public Animator animator;
    public int disapearingTime = 5;

    public bool isHidden ;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = 9;
    }

    // Update is called once per frame
    void Update()
    {
        if(isHidden == true){
            isHidden = false;
            StartCoroutine(appearing());
            }
        else{
            isHidden = true;
            StartCoroutine(disappearing());
        }

    }

    IEnumerator appearing(){
        gameObject.layer = 0;
        animator.SetBool("show", true);
        yield return new WaitForSeconds(disapearingTime);
    }

    IEnumerator disappearing(){
        gameObject.layer = 9;
        animator.SetBool("show", false);
        yield return new WaitForSeconds(disapearingTime);
    }
}
