using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Mask.Core
{
    [DisallowMultipleComponent]
    public class MaskBehaviour : MonoBehaviour
    {
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}