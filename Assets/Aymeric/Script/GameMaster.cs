using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public float countdown = 500f;
    public int high = 0;
    public int animation_nb = 0;

    void Awake()
    {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    
    private float GetScore(float maxTime = 500)
    {
        float time = maxTime - countdown;
        float defonce = 100 - high;
            
        float score = time + defonce;
        
        return score;
    }
}
