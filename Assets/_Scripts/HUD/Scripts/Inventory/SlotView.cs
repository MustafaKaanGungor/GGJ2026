using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace

namespace HUD.Inventory
{
    [DisallowMultipleComponent]
    public class SlotView : MonoBehaviour
    {
        [SerializeField] private Image iconView;
        
        private Sprite _icon;

        private void Start()
        {
            TryGetComponent(out iconView);
            iconView.sprite = _icon;
        }
    }
}