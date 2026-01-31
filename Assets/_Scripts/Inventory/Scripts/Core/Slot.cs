using Mask.Core;

// ReSharper disable once CheckNamespace

namespace Inventory.Core
{
    public class Slot
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public Mask.Core.Mask AttachedMask { get; private set; }
        public SlotType SlotType { get; private set; }

        public Slot(SlotType slotType)
        {
            SlotType = slotType;
        }

        public bool IsEmpty => AttachedMask == null;

        public void Attach(Mask.Core.Mask mask)
        {
            AttachedMask = mask;
        }
    }
}