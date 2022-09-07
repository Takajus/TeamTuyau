using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
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
}
