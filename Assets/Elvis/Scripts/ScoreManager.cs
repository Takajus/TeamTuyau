using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float GetScore(float maxTime, float currentTime, float currentDefonce)
    {
        float time = maxTime - currentTime;
        float defonce = 100 - currentDefonce;
            
        float score = time + defonce;
        
        return score;
    }
}
