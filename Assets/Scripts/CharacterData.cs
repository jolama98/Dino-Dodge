using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Create Character")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public float health;
    public float moveSpeed;
}