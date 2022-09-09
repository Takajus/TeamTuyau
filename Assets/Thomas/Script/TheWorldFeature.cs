using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorldFeature : MonoBehaviour
{
    public GameObject player;
    private PlayerController playerCtrl;
    [Header("\"The World\" duration")]
    [SerializeField]
    private float theWorldTimer;
    [Header("Character speed during \"The Wolrd\"")]
    [SerializeField]
    [Range(0.1f, 50.0f)]
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(TheWorldFunction());
        }
    }

    IEnumerator TheWorldFunction()
    {
        if (playerCtrl._canJump == true)
        {
            playerCtrl.Smoke();
            yield return new WaitForSeconds(2);
            Time.timeScale = 0.5f;
            playerCtrl.SetTimeScale(tempMultiplicator);
            yield return new WaitForSeconds(theWorldTimer);
            Time.timeScale = 1;
            playerCtrl.ResetSpeed();
        }
        else
            yield break;

    }
}
