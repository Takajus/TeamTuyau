using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject cursor;
    
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
        cursor.transform.localPosition = _positionCursor[0];
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.B))
            ChangeSelection();*/
    }

    private void ChangeSelection()
    {
        index++;
        
        if (index > _positionCursor.Length -1)
            index = 0;

        cursor.transform.localPosition = _positionCursor[index];
    }
}
