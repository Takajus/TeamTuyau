using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorldFeature : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private PlayerController playerCtrl;
    [SerializeField]
    private float theWorldTimer;
    private float tempSpeed;

    private void Start()
    {
        if (player.gameObject == null)
        {
            player = GameObject.FindGameObjectWithTag("player");
        }
        playerCtrl = player.GetComponent<PlayerController>();
        tempSpeed = playerCtrl.speed;

    }
    private void Update()
    {
        if (Input.GetKeyDown("E"))
        {

        }
    }

    IEnumerator TheWorldFunction()
    {
        Time.timeScale = Time.timeScale / 2;
        playerCtrl.speed = tempSpeed * 2;

        yield return new WaitForSecondsRealtime(theWorldTimer);

        Time.timeScale = 1;

        }

    }
}
