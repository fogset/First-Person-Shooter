using Cinemachine;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    float zoomedOutFOV = 60f;

    [SerializeField]
    float zoomedInFOV = 20f;

    bool zoomedInToggle = false;

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
                zoomedInToggle = true;

                virtualCamera.m_Lens.FieldOfView = zoomedInFOV;
                //Debug.Log("zoom in");
            }
            else
            {
                zoomedInToggle = false;

                virtualCamera.m_Lens.FieldOfView = zoomedOutFOV;
                //Debug.Log("zoom out");
            }
        }
    }
}
