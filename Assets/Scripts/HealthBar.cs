using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Attach to the GreenBar GameObject (a UI Image set to Filled / Horizontal).
/// Scales the fillAmount to reflect enemy health.
/// </summary>
public class HealthBar : MonoBehaviour
{
    private Image _fillImage;

    void Awake()
    {
        _fillImage = GetComponent<Image>();
        if (_fillImage == null)
            Debug.LogError("HealthBar: No Image component found on GreenBar!");
    }

    /// <summary>Update the bar. Call whenever health changes.</summary>
    public void SetHealth(int current, int max)
    {
        if (_fillImage == null) return;
        _fillImage.fillAmount = max > 0 ? (float)current / max : 0f;
    }
}
