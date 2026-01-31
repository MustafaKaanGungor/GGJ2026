using Player.Core;
using Stats.Core;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Mask.Core
{
    [DisallowMultipleComponent]
    public class MaskBehaviour : MonoBehaviour
    {
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public StatType Stat { get; private set; }
        [field: SerializeField] public byte Boost { get; private set; }
        [field: SerializeField] public LaserType LaserType { get; private set; }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
#pragma warning disable CS0618 // Type or member is obsolete
            var inventory = FindObjectOfType<PlayerBehaviour>().Inventory;
#pragma warning restore CS0618 // Type or member is obsolete
            if (inventory.TryGetFirstEmptySlot(out var slot))
            {
                var mask = new Mask(new MaskPerk(Stat, Boost), slot.SlotType, LaserType);
                mask.RegisterEvents();
                inventory.Add(slot.SlotType, mask, Icon);
            }
        }
    }
}