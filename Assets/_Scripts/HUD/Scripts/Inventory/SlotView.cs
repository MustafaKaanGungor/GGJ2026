using Inventory.Core;
using Mask.Core;
using Player.Core;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace

namespace HUD.Inventory
{
    [DisallowMultipleComponent]
    public class SlotView : MonoBehaviour
    {
        [SerializeField] private PlayerBehaviour player;
        [SerializeField] private Image iconView;
        [SerializeField] private SlotType slotType;

        private void OnEnable()
        {
            player.Inventory.OnAdd += OnAdd;
        }

        private void Start()
        {
            TryGetComponent(out iconView);
        }

        private void OnDisable()
        {
            player.Inventory.OnAdd -= OnAdd;
        }

        private void OnAdd(SlotType addedSlotType, MaskBehaviour maskBehaviour)
        {
            if (slotType != addedSlotType) return;

            if (player.Inventory.TryGetFirstEmptySlot(out var slot))
            {
                iconView.sprite = maskBehaviour.Icon;
            }
        }
    }
}