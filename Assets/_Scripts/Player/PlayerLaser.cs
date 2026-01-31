using System;
using Inventory.Core;
using Player.Core;
using UnityEngine;
public class PlayerLaser : MonoBehaviour
{
    public static event Action OnFire;
    
    [SerializeField] private GameObject laserObjectDefault;
    [SerializeField] private GameObject laserObjectHorizontal;
    [SerializeField] private Transform laserStartPoint;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Transform cam;
    [SerializeField] private 

    private float _timer;
    private float _interval;
    private PlayerBehaviour _playerBehaviour;

    private void OnEnable()
    {
        _playerBehaviour.OnMaskChange += OnMaskChange;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _timer = 0.0f;
        _interval = 0.25f;
        
        _playerBehaviour = PlayerBehaviour.Instance;
    }

    private void OnDisable()
    {
        _playerBehaviour.OnMaskChange -= OnMaskChange;
    }

    void Update()
    {
        if (_playerBehaviour.Inventory.Get(_playerBehaviour.CurrentActiveSlotType) == null)
        {
            laserObjectDefault.SetActive(false);
            return;
        }
        
        if(Input.GetKey(KeyCode.Mouse0))
        {
            _timer += Time.deltaTime;
            if (_timer >= _interval)
            {
                _timer = 0.0f;
                OnFire?.Invoke();
            }
            
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

    private void OnMaskChange(SlotType slotType, Mask.Core.Mask mask)
    {
        if (mask == null)
        {
            laserObjectDefault.SetActive(false);
            return;
        }
    }
}
