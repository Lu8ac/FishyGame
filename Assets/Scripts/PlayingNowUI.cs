using TMPro;
using UnityEngine;

/// <summary>
/// Attach to the Text (TMP) GameObject.
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class PlayingNowUI : MonoBehaviour
{
    [Header("Optional – leave blank to show 'Playing Now'")]
    public CharacterSheet characterSheet;

    private TMP_Text _label;

    void Awake()
    {
        _label = GetComponent<TMP_Text>();
    }

    void Start()
    {
        if (characterSheet != null)
            _label.text = $"Playing Now\n{characterSheet.characterName}";
        else
            _label.text = "Playing Now";
    }
}
