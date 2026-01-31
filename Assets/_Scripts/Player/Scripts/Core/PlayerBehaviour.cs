using Stats.Core;
using UnityEngine;

// ReSharper disable once CheckNamespace

namespace Player.Core
{
    [DisallowMultipleComponent]
    public class PlayerBehaviour : MonoBehaviour
    {
        public PlayerStats Stats { get; private set; } = new();
        public Inventory.Core.Inventory Inventory { get; private set; } = new();
    }
}