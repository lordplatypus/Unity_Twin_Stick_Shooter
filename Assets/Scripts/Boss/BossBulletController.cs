using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletController : TheRootOfAllEvil
{
    float speed = .05f;
    float speed2 = .05f;
    float angle;
    Rigidbody2D rb;
    Vector2 mousePosition;
    Vector2 position;
    Vector2 velocity;
    float angle2;
    float angleToMouse;
    float lifespan = 100;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        position = rb.position;
        position = GetComponent<Transform>().position;
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), boss.GetComponent<BoxCollider2D>());
    }

    public void SetPerameters(float speed, float angle, float lifespan)
    {
        this.speed = speed;
        this.angle = angle;
        velocity.x = Mathf.Cos(angle) * speed;
        velocity.y = Mathf.Sin(angle) * speed;
        this.lifespan = lifespan + Time.time;
    }

    void Update()
    {
        Trajectory();

        if (lifespan <= Time.time) 
        {//kill the bullet when its lifespan is up
            Kill();
        }
    }

    void Trajectory()
    {
        rb.AddForce(velocity);
    }
}
