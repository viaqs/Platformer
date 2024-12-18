using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 direction;
    public float speed = 20;
    public Vector2 damageRange = new Vector2(10, 20);

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var damage = Random.Range(damageRange.x, damageRange.y);

        var health = other.gameObject.GetComponent<Health>();
        if (health != null) 
        {
            health.TakeDamage((int)damage);
        }
        var enemyhealth = other.gameObject.GetComponent<EnemyHealth>();
        if (enemyhealth != null)
        {
            enemyhealth.TakeDamage((int)damage);
        }
        if(enemyhealth == null)
        {
            Destroy(enemy);
        }

        Destroy(gameObject);
    }
}