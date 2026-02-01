using DG.Tweening;
using Mask.Core;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace HUD.Inventory
{
    [DisallowMultipleComponent]
    public class PickupView : MonoBehaviour
    {
        private byte _selectedSlotIndex;

        private void OnEnable()
        {
            MaskBehaviour.OnMaskClaimWhenFull += OnClaimWhenFull;
        }

        private void OnDisable()
        {
            MaskBehaviour.OnMaskClaimWhenFull -= OnClaimWhenFull;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _selectedSlotIndex = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _selectedSlotIndex = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _selectedSlotIndex = 2;
            }
        }

        private void OnClaimWhenFull()
        {
            transform.DOMove(new Vector3(transform.position.x, 0.0f, transform.position.z), 0.25f);
        }
    }
}