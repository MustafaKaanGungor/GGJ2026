using System;
using Player.Core;
using Stats.Core;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Mask.Core
{
    [DisallowMultipleComponent]
    public class MaskBehaviour : MonoBehaviour
    {
        public static event Action OnMaskClaimWhenFull;
        
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public StatType Stat { get; private set; }
        [field: SerializeField] public byte Boost { get; private set; }
        [field: SerializeField] public LaserType LaserType { get; private set; }

        

        void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
            {
                Debug.Log("deydi???");
                #pragma warning disable CS0618 // Type or member is obsolete
                var inventory = player.Inventory;
                #pragma warning restore CS0618 // Type or member is obsolete

                if (inventory.TryGetFirstEmptySlot(out var slot))
                {
                    var mask = new Mask(
                        new MaskPerk(Stat, Boost),
                        slot.SlotType,
                        ((LaserType[])Enum.GetValues(typeof(LaserType)))[
                            UnityEngine.Random.Range(0, Enum.GetValues(typeof(LaserType)).Length)
                        ]
                    );

                    mask.RegisterEvents();
                    inventory.Add(slot.SlotType, mask, Icon);
                }
            }
            else
            {
                OnMaskClaimWhenFull?.Invoke();
            }
        }
    }
}