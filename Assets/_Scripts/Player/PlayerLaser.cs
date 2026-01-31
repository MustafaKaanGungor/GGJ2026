using System;
using Inventory.Core;
using Player.Core;
using UnityEngine;
public class PlayerLaser : MonoBehaviour
{
    public static event Action OnFire;
    
    [SerializeField] private Transform laserStartPoint;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Transform cam;
    [SerializeField] private LaserBehaviour[] laserBehaviours;

    private float _timer;
    private float _interval;
    private PlayerBehaviour _playerBehaviour;
    private LaserBehaviour _currentActiveLaserBehaviour;

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
            _currentActiveLaserBehaviour.gameObject.SetActive(false);
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
                    _currentActiveLaserBehaviour.transform.rotation = Quaternion.Slerp(_currentActiveLaserBehaviour.transform.rotation, targetRotation, rotationSpeed);
                }
            }
            _currentActiveLaserBehaviour.gameObject.SetActive(true);
        } else
        {
            _currentActiveLaserBehaviour.gameObject.SetActive(false);
        }
    }

    private void OnMaskChange(SlotType slotType, Mask.Core.Mask mask)
    {
        if (mask == null)
        {
            _currentActiveLaserBehaviour.gameObject.SetActive(false);
            return;
        }

        foreach (var laserBehaviour in laserBehaviours)
        {
            if (laserBehaviour.LaserType != mask.LaserType) continue;
            _currentActiveLaserBehaviour = laserBehaviour;
            break;
        }
    }
}
