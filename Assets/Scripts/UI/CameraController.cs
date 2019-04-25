using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour {

    [Header("Camera boundaries")]
    [SerializeField] private float X_Min;
    [SerializeField] private float X_Max;
    [SerializeField] private float Z_Min;
    [SerializeField] private float Z_Max;

    [SerializeField] private float _speedCamera;

    private Camera _camera;
    private void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        if(_camera != null)
            DoNavigation();
    }

    void DoNavigation()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            _camera.transform.position += new Vector3(-Input.GetAxis("Mouse X")*_speedCamera, 0, -Input.GetAxis("Mouse Y")*_speedCamera);

        _camera.transform.position = new Vector3(
            Mathf.Clamp(_camera.transform.position.x, X_Min, X_Max),
            _camera.transform.position.y,
            Mathf.Clamp(_camera.transform.position.z, Z_Min, Z_Max));
    }
}
