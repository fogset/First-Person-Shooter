using Cinemachine;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    StarterAssets.FirstPersonController fps_controller;

    [SerializeField]
    float zoomedOutFOV = 41f;

    [SerializeField]
    float zoomedInFOV = 20f;

    [SerializeField]
    float zoomedOutSensitivity = 2f;

    [SerializeField]
    float zoomedInSensitivity = 0.5f;

    //StarterAssets.FirstPersonController fps_controller;
    bool zoomedInToggle = false;

    // private void Start()
    // {
    //     fps_controller = GetComponent<StarterAssets.FirstPersonController>();
    // }
    private void OnDisable()
    {
        zoomOut();
    }

    private void Update()
    {
        Zoom();
    }

    private void Zoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                zoomedIn();
            }
            else
            {
                zoomOut();
            }
        }
    }

    private void zoomOut()
    {
        zoomedInToggle = false;
        virtualCamera.m_Lens.FieldOfView = zoomedOutFOV;
        fps_controller.RotationSpeed = zoomedOutSensitivity;
    }

    private void zoomedIn()
    {
        zoomedInToggle = true;
        virtualCamera.m_Lens.FieldOfView = zoomedInFOV;
        fps_controller.RotationSpeed = zoomedInSensitivity;
    }
}
