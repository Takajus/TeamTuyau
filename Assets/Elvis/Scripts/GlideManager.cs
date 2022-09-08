using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideManager : MonoBehaviour
{
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        
        player.GetComponent<PlayerController>().Glide();

        gameObject.GetComponent<GlideManager>().enabled = false;
    }
}
