using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject cursor, menu;
    [SerializeField]
    private TheWorldFeature TWFScript;
    [SerializeField]
    private PlayerController playerScript;
    [SerializeField]
    private GlideManager glideScript;

    public bool isMenuActive = false;
    
    public int cursorPos = 0;

    private Vector2[] _positionCursor =
    {
        new Vector2(-40, -45),
        new Vector2(3, -45),
        new Vector2(45, -45)
    };

    public int index = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        cursor.transform.localPosition = _positionCursor[2];

        if (TWFScript == null || playerScript == null || glideScript == null)
        {
            TWFScript = gameObject.GetComponent<TheWorldFeature>();
            playerScript = gameObject.GetComponent<PlayerController>();
            glideScript = gameObject.GetComponent<GlideManager>();
        }

        TWFScript.enabled = false;
        glideScript.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isMenuActive)
            {
                isMenuActive = true;
                menu.SetActive(isMenuActive);
            }
            else if (isMenuActive)
            {
                isMenuActive = false;
                TWFScript.enabled = false;
                glideScript.enabled = false;
                
                if (index == 3)
                {
                    print("button settup is wrong");
                    
                    TWFScript.enabled = false;
                    glideScript.enabled = false;
                }
                else if (index == 0)
                {
                    print("Plateforme");
                }
                else if (index == 1)
                {
                    print("THE WORLD");
                    TWFScript.enabled = true;

                    glideScript.enabled = false;
                }
                else if (index == 2)
                {
                    print("Glide");
                    glideScript.enabled = true;

                    TWFScript.enabled = false;
                }
                
                menu.SetActive(isMenuActive);
            }
        }
        if (Input.GetKeyDown(KeyCode.B))
            ChangeSelection();
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

        cursorPos = index;
        cursor.transform.localPosition = _positionCursor[index];
    }
}
