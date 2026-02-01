using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Stats.Core
{
    public class PlayerStats
    {
        public event Action OnDamaged;
        
        private const byte DefaultStatValue = 100;

        public byte Health { get; private set; } = DefaultStatValue;

        public Dictionary<StatType, byte> Stats { get; private set; } = new()
        {
            { StatType.Default, DefaultStatValue },
            { StatType.DamageAmplification, DefaultStatValue },
            { StatType.HealthRegenerationAmplification, DefaultStatValue },
            { StatType.RangeAmplification, DefaultStatValue },
            { StatType.EnemySpeedCurse, DefaultStatValue }
        };

        public void Damage(byte damage)
        {
            Health -= damage;
            if (Health <= 0) Health = 0;
            OnDamaged?.Invoke();
        }
    }
}