using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public int damage = 1;
    public Health playerHealth;
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentpoint;
    public float speed = 2f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentpoint = pointA.transform;

    }

    
    void Update()
    {
        Vector2 point = currentpoint.position - transform.position;
        if(currentpoint == pointA.transform)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
        }
        if(Vector2.Distance(transform.position, currentpoint.position) < 0.5f && currentpoint == pointA.transform)
        {
            flip();
            currentpoint = pointB.transform;
        }
        if(Vector2.Distance(transform.position, currentpoint.position) < 0.5f && currentpoint == pointB.transform)
        {
            flip();
            currentpoint = pointA.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
    private void flip()
    {
        Vector3 localscale = transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position,pointB.transform.position);

    }

}
