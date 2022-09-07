using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class High_gestion : MonoBehaviour
{

    private GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.high >25){
            defonce0();
        }
        else if(gm.high <=25 && gm.high >50){
            defonce1();
        }
        else if(gm.high <=50 && gm.high >75){
            defonce2();
        } 
        else if(gm.high <=75 && gm.high >100){
            defonce3();
        } else {
            defonce4();
        }

        
    }

    private void defonce0() {
        gm.animation_nb = 0;
    }

    private void defonce1() {
        gm.animation_nb = 1;
    }

    private void defonce2() {
        gm.animation_nb = 2;
    }

    private void defonce3() {
        gm.animation_nb = 3;
    }

    private void defonce4() {
        gm.animation_nb = 4;
    }
}
