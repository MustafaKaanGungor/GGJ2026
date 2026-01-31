using Player.Core;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
namespace HUD.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Image fill;

        private PlayerBehaviour _playerBehaviour;

        private void Start()
        {
            _playerBehaviour = PlayerBehaviour.Instance;
            _playerBehaviour.Stats.OnDamaged += OnDamaged;
            SyncHealth();
        }

        private void SyncHealth()
        {
            fill.fillAmount = _playerBehaviour.Stats.Health / 100.0f;
        }

        private void OnDamaged()
        {
            SyncHealth();
        }
    }
}