using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 10;

    [SerializeField]
    private int health;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (!isDead)
        {
            isDead = (health -= damage) <= 0;
        }
        else
        {
            Debug.Log("Player is dead!");
        }
    }
}
