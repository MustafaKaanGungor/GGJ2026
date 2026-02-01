using Player.Core;
using Stats.Core;
using UnityEngine;
using UnityEngine.UI;

public class PickupSlotView : MonoBehaviour
{
    [SerializeField] private Image statIcon;

    public void UpdateView(StatType statType)
    {
        var playerBehaviour = PlayerBehaviour.Instance;
        if (playerBehaviour == null || playerBehaviour.StatIcons == null) return;

        var requiredKeyword = GetKeyword(statType);

        if (string.IsNullOrEmpty(requiredKeyword)) return;

        foreach (var icon in playerBehaviour.StatIcons)
        {
            if (icon == null) continue;

            var iconName = icon.name.ToLowerInvariant();

            if (!iconName.Contains(requiredKeyword)) continue;
            statIcon.sprite = icon;
            return;
        }

        Debug.LogWarning($"No icon found for stat type {statType}");
    }

    private string GetKeyword(StatType statType)
    {
        return statType switch
        {
            StatType.DamageAmplification => "damage",
            StatType.HealthRegenerationAmplification => "health",
            StatType.RangeAmplification => "range",
            _ => null
        };
    }
}