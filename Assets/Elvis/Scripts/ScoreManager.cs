using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private float maxTime;
    [SerializeField]
    private float maxDefonce = 100;
    
    private float _currentTime;

    private float GetScore(float currentDefonce)
    {
        float time = maxTime - _currentTime;
        float defonce = maxDefonce - currentDefonce;
            
        float score = time + defonce;
        
        return score;
    }
}
