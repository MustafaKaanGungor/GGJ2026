using Player.Core;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Mask.Core
{
    [DisallowMultipleComponent]
    public class MaskBehaviour : MonoBehaviour
    {
        [field: SerializeField] public Sprite Icon { get; private set; }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
#pragma warning disable CS0618 // Type or member is obsolete
            var inventory = FindObjectOfType<PlayerBehaviour>().Inventory;
#pragma warning restore CS0618 // Type or member is obsolete
            if (inventory.TryGetFirstEmptySlot(out var slot))
            {
                inventory.Add(slot.SlotType, this);
            }
        }
    }
}