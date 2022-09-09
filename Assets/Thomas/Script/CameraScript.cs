using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.U2D;

public class CameraScript : MonoBehaviour
{
    [Header("Camera component")]
    public GameObject _camera;
    private Vector2 cameraPos;
    public bool a;


    [Header("Player")]
    public GameObject _player;


    private void Start()
    {
        /*if(_player.gameObject == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }*/

        if(_camera.GetComponent<PixelPerfectCamera>() == null)
        {
                _camera.AddComponent<PixelPerfectCamera>();
        }
        _camera.GetComponent<PixelPerfectCamera>().refResolutionX = 160;
        _camera.GetComponent<PixelPerfectCamera>().refResolutionY = 144;

        _camera.GetComponent<PixelPerfectCamera>().assetsPPU = 16;
        cameraPos = _camera.transform.position;
        a = false;
    }

    private void Update()
    {
        cameraPos = _camera.transform.position;
        if (cameraPos.y <= 0)
        {
            cameraPos.y = 0;
        }
        if (_player.transform.position.x >= cameraPos.x - 0.5f && _player.transform.position.y >= cameraPos.y + 2f)
        {
            _camera.transform.position = new Vector3(_player.transform.position.x + 0.5f, _player.transform.position.y - 2f, -10);
            a = true;
        }
        else if (_player.transform.position.x <= cameraPos.x - 0.5f && _player.transform.position.y >= cameraPos.y + 2f)
        {
            _camera.transform.position = new Vector3(cameraPos.x, _player.transform.position.y - 2f, -10);
            a = true;
        }
        else if (_player.transform.position.x <= cameraPos.x - 0.5f && _player.transform.position.y < cameraPos.y - 1f && cameraPos.y > 0)
        {
            _camera.transform.position = new Vector3(cameraPos.x, _player.transform.position.y + 1f, -10);
            a = true;
        }
        else if (_player.transform.position.x >= cameraPos.x - 0.5f && _player.transform.position.y < cameraPos.y - 1f && cameraPos.y > 0)
        {
            _camera.transform.position = new Vector3(_player.transform.position.x + 0.5f, _player.transform.position.y + 1f, -10);
            a = true;
        }
        else if (_player.transform.position.x >= cameraPos.x - 0.5f)
        {
            _camera.transform.position = new Vector3(_player.transform.position.x + 0.5f, cameraPos.y, -10);
            a = true;
        }


    }
}
