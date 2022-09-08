using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    
    private delegate void Action();

    private Action _action;
    
    // Start is called before the first frame update
    void Start()
    {
        _action = EndGame;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _action();
            col.gameObject.GetComponent<PlayerController>().SetCanMove(false);
        }
    }

    private void EndGame()
    {
        print("End Game");
    }
}
