using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private SpriteRenderer sprite;

    private Rigidbody2D rb2d;
    public Vector2 a, b;
    [Range(0, 1)]
    public float speed = 1.0f;
    public float c, d;
    private CapsuleCollider2D capsuleCollider2d;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        capsuleCollider2d = GetComponent<CapsuleCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(a, b, Mathf.PingPong(Time.time * speed, 1));

        if (rb2d.worldCenterOfMass.x <= c)
        {
            sprite.flipX = false;
            
        }
        if (rb2d.worldCenterOfMass.x >= d)
        {
            sprite.flipX = true;
            
        }
    }

    
    
}
    
