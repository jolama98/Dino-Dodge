using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Character", menuName = "Create Character")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public int health;
    public int attackPower;
    public float speed;
    public Animator animator;
    // You can add more character-related data here



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
