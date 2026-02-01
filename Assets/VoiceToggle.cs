using UnityEngine;
using UnityEngine.UI;

public class VoiceToggle : MonoBehaviour
{
    [SerializeField] private Sprite toggleOn;
    [SerializeField] private Sprite toggleOff;
    [SerializeField] private Image image;

    private void Start()
    {
        UpdateSprite();
    }

    public void Toggle()
    {
        AudioListener.pause = !AudioListener.pause;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        image.sprite = AudioListener.pause ? toggleOff : toggleOn;
    }
}