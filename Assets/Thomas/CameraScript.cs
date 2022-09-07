using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.U2D;

public class CameraScript : MonoBehaviour
{
    public GameObject _camera;

    public GameObject _player;


    private void Start()
    {
        if(_player.gameObject == null)
        {
            _player = GameObject.FindGameObjectWithTag("player");
        }

        if(_camera.GetComponent<PixelPerfectCamera>() == null)
        {
                _camera.AddComponent<PixelPerfectCamera>();
        }
        _camera.GetComponent<PixelPerfectCamera>().refResolutionX = 160;
        _camera.GetComponent<PixelPerfectCamera>().refResolutionY = 144;

        _camera.GetComponent<PixelPerfectCamera>().assetsPPU = 16;
    }
}
