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

    public GameObject logo1;
    public GameObject logo2;
    public GameObject logo3;

    public bool isMenuActive = false;
    
    public int cursorPos = 0;

    private Vector2[] _positionCursor =
    {
        new Vector2(-47, -45),
        new Vector2(0, -45),
        new Vector2(47, -45)
    };

    public int index = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        cursor.transform.localPosition = _positionCursor[index];

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
                    logo1.SetActive(true);
                    logo2.SetActive(false);
                    logo3.SetActive(false);
                }
                else if (index == 1)
                {
                    print("THE WORLD");
                    TWFScript.enabled = true;

                    glideScript.enabled = false;
                    logo1.SetActive(false);
                    logo2.SetActive(true);
                    logo3.SetActive(false);
                }
                else if (index == 2)
                {
                    print("Glide");
                    glideScript.enabled = true;

                    TWFScript.enabled = false;
                    logo1.SetActive(false);
                    logo2.SetActive(false);
                    logo3.SetActive(true);
                }
                
                menu.SetActive(isMenuActive);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Q) && isMenuActive)
        {
            ChangeSelection(false);
        }
        if (Input.GetKeyDown(KeyCode.D) && isMenuActive)
            ChangeSelection(true);
    }

    public void ChangeSelection(bool right = true)
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
        Debug.LogWarning("Cusror moved: index " + index + " - pos "+_positionCursor[index]);
    }
}
