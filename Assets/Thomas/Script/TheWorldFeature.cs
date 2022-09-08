using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorldFeature : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerCtrl;
    [Header("\"The World\" duration")]
    [SerializeField]
    private float theWorldTimer;
    [Header("Character speed during \"The Wolrd\"")]
    [SerializeField][Range(0.1f, 1.0f)]
    private float tempMultiplicator;

    private void Start()
    {
        if (player.gameObject == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            playerCtrl = player.GetComponent<PlayerController>();
        }
            

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
