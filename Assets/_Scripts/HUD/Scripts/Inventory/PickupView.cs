using DG.Tweening;
using Mask.Core;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
namespace HUD.Inventory
{
    [DisallowMultipleComponent]
    public class PickupView : MonoBehaviour
    {
        private byte _selectedSlotIndex;
        private bool _isActive;

        [SerializeField] private Image fill;
        [SerializeField] private float moveDuration = 0.25f;
        [SerializeField] private float drainDuration = 0.5f;

        private Vector3 _originalPosition;
        private Sequence _sequence;

        private void Awake()
        {
            _originalPosition = transform.position;
            fill.fillAmount = 1f;
        }

        private void OnEnable()
        {
            MaskBehaviour.OnMaskClaimWhenFull += OnClaimWhenFull;
        }

        private void OnDisable()
        {
            MaskBehaviour.OnMaskClaimWhenFull -= OnClaimWhenFull;
        }

        private void OnClaimWhenFull()
        {
            if (_sequence != null && _sequence.IsActive())
                _sequence.Kill();

            _isActive = true;

            _sequence = DOTween.Sequence();

            // move in
            _sequence.Append(
                transform.DOMove(
                    new Vector3(transform.position.x, 0.0f, transform.position.z),
                    moveDuration
                )
            );

            // drain fill
            _sequence.Append(
                fill.DOFillAmount(0f, drainDuration)
            );

            // move back to original position
            _sequence.Append(
                transform.DOMove(_originalPosition, moveDuration)
            );

            // reset fill when everything is done
            _sequence.OnComplete(() =>
            {
                fill.fillAmount = 1f;
                _isActive = false;
            });
        }
    }
}