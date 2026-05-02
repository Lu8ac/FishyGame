using UnityEngine;
using UnityEngine.InputSystem;
 
/// <summary>
/// Attach to the CharacterController GameObject.
/// Drives the D20 attack simulation every time the player presses Space.
/// </summary>
[RequireComponent(typeof(CharacterSheet))]
public class CombatManager : MonoBehaviour
{
    [Header("References")]
    public Enemy enemy;                         // drag the Enemy GameObject here
    public HealthBar healthBar;                 // drag the GreenBar UI here
 
    private CharacterSheet _sheet;
 
    void Start()
    {
        _sheet = GetComponent<CharacterSheet>();
 
        if (enemy != null)
        {
            enemy.OnHealthChanged += (cur, max) => healthBar?.SetHealth(cur, max);
            enemy.OnDeath += () => Debug.Log("Enemy has been defeated!");
 
            // Initialise health bar
            healthBar?.SetHealth(enemy.currentHealth, enemy.maxHealth);
        }
    }
 
    void Update()
    {
        // Press Space to attack
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            Attack();
    }
 
    public void Attack()
    {
        if (enemy == null) { Debug.LogWarning("No enemy assigned!"); return; }
        if (enemy.currentHealth <= 0) { Debug.Log("Enemy is already dead."); return; }
 
        int d20 = Random.Range(1, 21);
        enemy.ReceiveAttack(d20, _sheet.hitModifier, _sheet.characterName);
    }
}