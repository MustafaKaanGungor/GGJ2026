using Player.Core;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Transform[] toSetActive;
    private PlayerBehaviour _player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = PlayerBehaviour.Instance;
        _player.Inventory.Cleared += OnCleared;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCleared()
    {
        for (var i = 0; i < toSetActive.Length; i++)
        {
            toSetActive[i].gameObject.SetActive(true);
        }
    }
}