using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterData baseCharacter;
    public float currentHealth;
    public float moveSpeed;

    public void Start()
    {
        Debug.Log(baseCharacter.characterName);
        currentHealth = baseCharacter.health;
        moveSpeed = baseCharacter.moveSpeed;
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{baseCharacter.characterName} currentHealth: {currentHealth}");
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}