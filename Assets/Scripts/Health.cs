using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 6;
    public List<Image> hearts;
    public Sprite Full;
    public Sprite Half;
    public Sprite Empty;
    private int health;

    void Start()
    {
        health = maxHealth;
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health < 0)
        {
            health = 0;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        UpdateHearts();
    }
    
    void UpdateHearts()
    {
        for(int i = 0; i < hearts.Count; i++)
        {
            if(health>=(i+1) * 2)
            {
                hearts[i].sprite = Full;
            }
            else if(health == (1 * 2) + 1)
            {
                hearts[i].sprite = Half;
            }
            else
            {
                hearts[i].sprite = Empty;
            }
        }
    }
}
