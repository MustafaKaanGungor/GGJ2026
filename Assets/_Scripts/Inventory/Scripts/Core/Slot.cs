using UnityEngine;

// ReSharper disable once CheckNamespace

namespace Inventory.Core
{
    public class Slot
    {
        // TODO: Replace with actual mask behaviour later.
        // ReSharper disable once MemberCanBePrivate.Global
        public GameObject AttachedMask { get; private set; }

        public bool IsEmpty => AttachedMask == null;

        // TODO: Replace the parameter with actual mask behaviour later.
        public void Attach(GameObject mask)
        {
            AttachedMask = mask;
        }
    }
}