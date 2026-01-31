using UnityEngine;
public class PlayerLaser : MonoBehaviour
{
    [SerializeField] private GameObject laserObjectDefault;
    [SerializeField] private GameObject laserObjectHorizontal;
    [SerializeField] private Transform laserStartPoint;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Transform cam;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            if(Physics.Raycast(cam.position, cam.forward, out RaycastHit hitInfo))
            {
                Vector3 direction = hitInfo.point - laserStartPoint.position;
                if(direction.magnitude >= 0.1f)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    laserObjectHorizontal.transform.rotation = Quaternion.Slerp(laserObjectHorizontal.transform.rotation, targetRotation, rotationSpeed);
                }
            }
            laserObjectHorizontal.SetActive(true);
        } else
        {
            laserObjectHorizontal.SetActive(false);
        }
    }
}
