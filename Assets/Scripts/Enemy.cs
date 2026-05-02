using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int maxHealth = 30;
    public int currentHealth;
    public int armorClass; // randomly assigned at start

    public event System.Action<int, int> OnHealthChanged; // current, max
    public event System.Action OnDeath;

    void Awake()
    {
        // Random AC between 10 and 20
        armorClass = Random.Range(10, 21);
        currentHealth = maxHealth;
        Debug.Log($"Enemy AC is {armorClass}");
    }

    /// <summary>Returns true if the attack hits.</summary>
    public bool ReceiveAttack(int d20Roll, int hitModifier, string attackerName)
    {
        int total = d20Roll + hitModifier;
        Debug.Log($"{attackerName} rolled a {d20Roll} (total: {total})");

        if (total >= armorClass)
        {
            Debug.Log("Direct hit! The enemy staggers!");
            TakeDamage(5); // flat damage for demo
            return true;
        }
        else
        {
            Debug.Log($"Missed! {attackerName}'s attack whooshes harmlessly past the enemy.");
            return false;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth = Mathf.Max(0, currentHealth - amount);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        if (currentHealth <= 0)
            OnDeath?.Invoke();
    }
}
