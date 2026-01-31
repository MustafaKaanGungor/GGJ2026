using System;
using Inventory.Core;
using Player.Core;

// ReSharper disable once CheckNamespace
namespace Mask.Core
{
    public class Mask
    {
        public static event Action OnDegrade;
        public event Action<SlotType, byte> OnConditionUpdate;

        public MaskPerk Perk;
        public SlotType SlotType;

        private const byte DefaultCondition = 100;
        private const byte MinimumCondition = 0;

        public byte Condition { get; set; } = DefaultCondition;

        public Mask(MaskPerk perk, SlotType slotType)
        {
            Perk = perk;
            SlotType = slotType;
        }

        public void RegisterEvents()
        {
            PlayerLaser.OnFire += Damage;
        }

        public void UnregisterEvents()
        {
            PlayerLaser.OnFire -= Damage;
        }

        public void Damage()
        {
            if (SlotType != PlayerBehaviour.Instance.CurrentActiveSlotType) return;
            
            if (Condition == MinimumCondition) return;
            Condition -= 1;
            OnConditionUpdate?.Invoke(SlotType, Condition);
            if (Condition == MinimumCondition) OnDegrade?.Invoke();
        }
    }
}