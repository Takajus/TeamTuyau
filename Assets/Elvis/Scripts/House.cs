using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class House : MonoBehaviour
{
    [SerializeField] 
    private float delai = 2;
    
    private delegate void Action();

    private Action _action;
    
    // Start is called before the first frame update
    void Start()
    {
        _action = EndGame;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerController>().SetCanMove(false);
            _action();
        }
    }

    private void EndGame()
    {
        StartCoroutine(DelaiBeforeLoad(delai));
    }

    IEnumerator DelaiBeforeLoad(float delai)
    {
        yield return new WaitForSeconds(delai);
        SceneManager.LoadScene("MainMenu");
    }
}
