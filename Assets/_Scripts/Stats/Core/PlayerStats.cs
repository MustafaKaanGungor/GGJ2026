using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Stats.Core
{
    public class PlayerStats
    {
        private const byte DefaultStatValue = 100;

        public Dictionary<StatType, byte> Stats { get; private set; } = new()
        {
            { StatType.Default, DefaultStatValue },
            { StatType.DamageAmplification, DefaultStatValue },
            { StatType.HealthRegenerationAmplification, DefaultStatValue },
            { StatType.RangeAmplification, DefaultStatValue },
            { StatType.EnemySpeedCurse, DefaultStatValue }
        };
    }
}