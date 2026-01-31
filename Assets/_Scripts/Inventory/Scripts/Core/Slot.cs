using Mask.Core;

// ReSharper disable once CheckNamespace

namespace Inventory.Core
{
    public class Slot
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public MaskBehaviour AttachedMask { get; private set; }

        public bool IsEmpty => AttachedMask == null;

        public void Attach(MaskBehaviour maskBehaviour)
        {
            AttachedMask = maskBehaviour;
        }
    }
}