using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class High_gestion : MonoBehaviour
{
    private bool Isdown;
    // Start is called before the first frame update
    void Start()
    {
        Isdown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameMaster.instance.high <25){
            defonce0();
        }
        else if(GameMaster.instance.high >=25 && GameMaster.instance.high <50){
            defonce1();
        }
        else if(GameMaster.instance.high >=50 && GameMaster.instance.high <75){
            defonce2();
        } 
        else if(GameMaster.instance.high >=75 && GameMaster.instance.high <100){
            defonce3();
        } 
        else {
            defonce4();
        }

        if(Isdown == true){
            Isdown = false;
            StartCoroutine(Fade());
            }
    }

    private void defonce0() {
        GameMaster.instance.animation_nb = 0;
    }

    private void defonce1() {
        GameMaster.instance.animation_nb = 1;
    }

    private void defonce2() {
        GameMaster.instance.animation_nb = 2;
    }

    private void defonce3() {
        GameMaster.instance.animation_nb = 3;
    }

    private void defonce4() {
        GameMaster.instance.animation_nb = 4;
    }

    IEnumerator Fade(){
    if( GameMaster.instance.high>0) {
        GameMaster.instance.high = GameMaster.instance.high - 5;
        yield return new WaitForSeconds(5);
        
    }
    Isdown = true;
    }
}


