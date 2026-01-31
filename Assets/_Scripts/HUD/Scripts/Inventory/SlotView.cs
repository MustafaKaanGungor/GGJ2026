using Inventory.Core;
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
        [SerializeField] private Image[] toBeUpdated;
        [SerializeField] private Color highlightedColor;
        [SerializeField] private Image fill;

        private Color[] _defaultColors;

        private void OnEnable()
        {
            player.Inventory.OnAdd += OnAdd;
            player.OnMaskChange += OnMaskChange;
        }

        private void Start()
        {
            _defaultColors = new Color[toBeUpdated.Length];
            for (var i = 0; i < _defaultColors.Length; i++) _defaultColors[i] = toBeUpdated[i].color;
        }

        private void OnDisable()
        {
            player.Inventory.OnAdd -= OnAdd;
            player.OnMaskChange -= OnMaskChange;
        }

        private void OnAdd(SlotType addedSlotType, Mask.Core.Mask mask, Sprite icon)
        {
            if (slotType != addedSlotType) return;

            iconView.sprite = icon;

            // TODO: Unsubscribe when mask is removed.
            mask.OnConditionUpdate += OnConditionUpdate;

            fill.fillAmount = mask.Condition / 100.0f;
        }

        private void OnMaskChange(SlotType changedSlotType, Mask.Core.Mask mask)
        {
            if (slotType != changedSlotType)
            {
                for (var i = 0; i < toBeUpdated.Length; i++) toBeUpdated[i].color = _defaultColors[i];
                return;
            }

            foreach (var image in toBeUpdated) image.color = highlightedColor;

            if (mask == null) return;

            fill.fillAmount = mask.Condition / 100.0f;
        }

        private void OnConditionUpdate(byte condition)
        {
            fill.fillAmount = condition / 100.0f;
        }
    }
}