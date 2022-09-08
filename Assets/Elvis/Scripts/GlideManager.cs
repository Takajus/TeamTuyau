using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideManager : MonoBehaviour
{
    private GameObject player;
    
    private void OnEnable()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        
        player.GetComponent<PlayerController>().Glide();

        gameObject.GetComponent<GlideManager>().enabled = false;
    }
}
