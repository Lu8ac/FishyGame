using UnityEngine;
 
/// <summary>
/// connects all scripts in the scene
/// </summary>
public class SceneBootstrapper : MonoBehaviour
{
    void Start()
    {
        // -- CharacterSheet
        CharacterSheet sheet = FindObjectOfType<CharacterSheet>();
        if (sheet == null) { Debug.LogError("SceneBootstrapper: No CharacterSheet found!"); return; }
 
        // -- Enemy
        Enemy enemy = FindObjectOfType<Enemy>();
        if (enemy == null) { Debug.LogError("SceneBootstrapper: No Enemy found!"); return; }
 
        // -- HealthBar (GreenBar)
        HealthBar healthBar = FindObjectOfType<HealthBar>();
        if (healthBar == null) Debug.LogWarning("SceneBootstrapper: No HealthBar found — GreenBar may not be set up yet.");
 
        // -- CombatManager
        CombatManager combat = FindObjectOfType<CombatManager>();
        if (combat != null)
        {
            combat.enemy     = enemy;
            combat.healthBar = healthBar;
        }
        else
        {
            Debug.LogWarning("SceneBootstrapper: No CombatManager found!");
        }
 
        // -- PlayingNowUI
        PlayingNowUI ui = FindObjectOfType<PlayingNowUI>();
        if (ui != null)
            ui.characterSheet = sheet;
 
        // -- Initialise health bar with current enemy health
        if (healthBar != null)
            healthBar.SetHealth(enemy.currentHealth, enemy.maxHealth);
 
        Debug.Log("SceneBootstrapper: Scene wired successfully!");
    }
}
 