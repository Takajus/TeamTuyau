using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timemanager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _txtTimer;



    // Start is called before the first frame update
    public void Start()
    {
        //_txtTimer = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void Update()
    {
    GameMaster.instance.countdown -= Time.deltaTime;

    //_txtTimer.text = "Timer: " + GameMaster.instance.countdown.ToString();
    }
}
