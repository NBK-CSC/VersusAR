using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchingTheCameras : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Camera _camera;
    
    private void Start()
    {
        _camera=Camera.main;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _camera.transform.position);
    }
}
