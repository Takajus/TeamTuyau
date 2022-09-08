using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject cursor, menu;

    private TheWorldFeature TWFScript;
    private PlayerController playerScript;
    private GlideManager glideScript;

    public bool _featuresChose = false;
    private int cursorPos;

    private Vector2[] _positionCursor =
    {
        new Vector2(-40, -45),
        new Vector2(3, -45),
        new Vector2(45, -45)
    };

    private int index = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        cursor.transform.localPosition = _positionCursor[2];

        if (!TWFScript || !playerScript || !glideScript)
        {
            TWFScript = gameObject.GetComponent<TheWorldFeature>();
            playerScript = gameObject.GetComponent<PlayerController>();
            glideScript = gameObject.GetComponent<GlideManager>();
        }

        TWFScript.enabled = false;
        playerScript.enabled = false;
        glideScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("Cancel"))
        {
            if (Time.timeScale == 0)
            {
                if (cursorPos == 3)
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

                menu.SetActive(false);
                Time.timeScale = 1;

            }
            if (Time.timeScale == 1)
            {
                menu.SetActive(true);
                Time.timeScale = 0;

                TWFScript.enabled = false;
                playerScript.enabled = false;
                glideScript.enabled = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.B))
            ChangeSelection(false);
    }

    private void ChangeSelection(bool right = true)
    {
        if (right)
        {
            index++;
        
            if (index > _positionCursor.Length -1)
                index = 0;
        }
        else
        {
            index--;
        
            if (index < 0)
                index = 2;
        }

        cursor.transform.localPosition = _positionCursor[index];
    }
}
