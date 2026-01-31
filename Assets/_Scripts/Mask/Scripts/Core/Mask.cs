using System;
using Inventory.Core;

// ReSharper disable once CheckNamespace
namespace Mask.Core
{
    public class Mask
    {
        public static event Action OnDegrade;
        public event Action<byte> OnConditionUpdate;

        public MaskPerk Perk;

        private const byte DefaultCondition = 100;
        private const byte MinimumCondition = 0;

        public byte Condition { get; set; } = DefaultCondition;

        public Mask(MaskPerk perk)
        {
            Perk = perk;
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
            if (Condition == MinimumCondition) return;
            Condition -= 1;
            OnConditionUpdate?.Invoke(Condition);
            if (Condition == MinimumCondition) OnDegrade?.Invoke();
        }
    }
}