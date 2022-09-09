using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafPlatform : MonoBehaviour
{
    public Animator animator;
    private bool up = false;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetTrigger("Up");
        up = true;
        StartCoroutine(DelayLeaf(2f));
    }

    private IEnumerator DelayLeaf(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (up)
        {
            animator.SetTrigger("Down");
            up=false;
            StartCoroutine(DelayLeaf(2.5f));
        }
        else if (!up)
        {
            animator.SetTrigger("Up");
            up = true;
            StartCoroutine(DelayLeaf(2f));
        }

    }
}
