using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ennemy_movement : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public Transform[] waypoints;
    public SpriteRenderer graphics;
    
    private Transform target;
    private int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = 10;
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {

    Vector3 dir = target.position - transform.position;
    transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

    // Si l'ennemi est quasiment arrivé à sa destination
    if(Vector3.Distance(transform.position, target.position) < 0.3f)
    {
        destPoint = (destPoint + 1) % waypoints.Length;
        target = waypoints[destPoint];
        graphics.flipX = !graphics.flipX;
    }

    animator.SetInteger("animationNumber", GameMaster.instance.animation_nb);

    }
    
}
