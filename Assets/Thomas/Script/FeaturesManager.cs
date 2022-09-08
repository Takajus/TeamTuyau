using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeaturesManager : MonoBehaviour
{
    private TheWorldFeature TWFScript;
    private PlayerController playerScript;
    private GlideManager glideScript;
    // canvas

    public bool _featuresChose = false;
    private int cursorPos;

    private void Start()
    {

        if(!TWFScript || !playerScript || !glideScript)
        {
            TWFScript = gameObject.GetComponent<TheWorldFeature>();
            playerScript = gameObject.GetComponent<PlayerController>();
            glideScript = gameObject.GetComponent<GlideManager>();
        }

        TWFScript.enabled = false;
        playerScript.enabled = false;
        glideScript.enabled = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown("Cancel"))
        {
            if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
        }

        if(Time.timeScale == 0)
        {
            TWFScript.enabled = false;
            playerScript.enabled = false;
            glideScript.enabled = false;

            if (cursorPos == -1)
            {
                print("button settup is wrong");
            }
            else if (cursorPos == 0)
            {
                print("Plateforme");
            }
            else if (cursorPos == 1)
            {
                print("THE WORLD");
                TWFScript.enabled = true;
            }
            else if (cursorPos == 2)
            {
                print("Glide");
                glideScript.enabled = true;
            }
        }
    }
}
