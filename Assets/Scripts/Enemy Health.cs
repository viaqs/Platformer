using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 6;
    private int health;
    public AudioClip damageSound;
    public AudioSource damageSource;
    void Start()
    {
        health = maxHealth; 
    }

    public void TakeDamage(int damage)
    {   
        damageSource.PlayOneShot(damageSound);
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
