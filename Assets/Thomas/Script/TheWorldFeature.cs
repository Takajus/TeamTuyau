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
    [SerializeField]
    private float tempMultiplicator;

    private void Start()
    {
        if (player.gameObject == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        playerCtrl = player.GetComponent<PlayerController>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(TheWorldFunction());
        }
    }

    IEnumerator TheWorldFunction()
    {
        Time.timeScale = Time.timeScale / 2;
        playerCtrl.SetTimeScale(tempMultiplicator);

        yield return new WaitForSecondsRealtime(theWorldTimer);

        Time.timeScale = 1;
        playerCtrl.ResetSpeed();
    }
}
