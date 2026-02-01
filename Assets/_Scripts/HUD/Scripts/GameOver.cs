using Dreamteck.Forever;
using Player.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        _player.GetComponent<Runner>().followSpeed = 0.0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadActiveScene()
    {
        SceneManager.LoadScene(1);
    }
}