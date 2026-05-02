using UnityEngine;

public class CharacterSheet : MonoBehaviour
{
    [Header("Character Info")]
    public string characterName = "Fishy";

    [Header("Combat Stats")]
    public int proficiencyBonus = 2;
    public bool finesseWeapon = false;

    [Header("Ability Modifiers (-5 to +5)")]
    [Range(-5, 5)] public int strModifier = 0;
    [Range(-5, 5)] public int dexModifier = 0;

    [HideInInspector] public int hitModifier;

    void Awake()
    {
        // Calculate hit modifier based on finesse weapon rule
        int abilityModifier;
        if (finesseWeapon)
            abilityModifier = Mathf.Max(strModifier, dexModifier);
        else
            abilityModifier = strModifier;

        hitModifier = abilityModifier + proficiencyBonus;

        // Bonus: format sign
        string hitModifierStr = hitModifier >= 0 ? $"+{hitModifier}" : $"{hitModifier}";
        Debug.Log($"{characterName}'s hit modifier is {hitModifierStr}");
    }
}
