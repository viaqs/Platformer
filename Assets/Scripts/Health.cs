using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public AudioClip damageSound;
    public int maxHealth = 6;
    public List<Image> hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
  
    public UnityEvent onDeath;

    private int health;
   
    public AudioSource audioSource;

    void Start()
    {
        
        health = maxHealth;
       
    }


    public void TakeDamage(int damage)
    {
        audioSource.PlayOneShot(damageSound);

        health -= damage;
        

        if (health <= 0)
        {
            health = 0;
            onDeath.Invoke();
        }

        UpdateHearts();


    }

    public void die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (health >= (i + 1) * 2)
            {
                hearts[i].sprite = fullHeart;
            }
            else if (health == (i * 2) + 1)
            {
                hearts[i].sprite = halfHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}