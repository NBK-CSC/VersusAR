using UnityEngine;

public class WatchingTheCamera : MonoBehaviour
{
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
