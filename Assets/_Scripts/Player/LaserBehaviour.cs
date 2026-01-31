using UnityEngine;

[DisallowMultipleComponent]
// ReSharper disable once CheckNamespace
public class LaserBehaviour : MonoBehaviour
{
    [field: SerializeField] public LaserType LaserType { get; set; }
}
