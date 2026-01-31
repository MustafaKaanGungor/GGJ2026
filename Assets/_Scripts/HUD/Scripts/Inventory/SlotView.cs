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

        private void OnDisable()
        {
            player.Inventory.OnAdd -= OnAdd;
        }

        private void OnAdd(SlotType addedSlotType, MaskBehaviour maskBehaviour)
        {
            if (slotType != addedSlotType) return;

            Debug.Log($"Added slot type {addedSlotType}, self slot type was {slotType}");

            iconView.sprite = maskBehaviour.Icon;
        }
    }
}