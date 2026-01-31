using Stats.Core;

// ReSharper disable once CheckNamespace

namespace Mask.Core
{
    public readonly struct MaskPerk
    {
        public readonly StatType Stat;
        public readonly byte Boost;

        public MaskPerk(StatType stat, byte boost)
        {
            Stat = stat;
            Boost = boost;
        }
    }
}