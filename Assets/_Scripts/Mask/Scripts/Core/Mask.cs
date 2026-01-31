using System;

// ReSharper disable once CheckNamespace
namespace Mask.Core
{
    public class Mask
    {
        public event Action OnDegrade;

        private const byte DefaultCondition = 100;
        private const byte MinimumCondition = 0;

        private byte Condition { get; set; } = DefaultCondition;

        public void Damage(byte damage)
        {
            if (Condition == MinimumCondition) return;
            Condition -= damage;
            if (Condition == MinimumCondition) OnDegrade?.Invoke();
        }
    }
}