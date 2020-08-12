using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : EnemyClass
{
    Vector2 velocity;
    Vector2 position;    
    float vx;
    float vy;
    float angleToPlayer;
    Rigidbody2D playerRB;
    int loseInterestCount = 180;
    bool lostVisual = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        minimapIcon = GameObject.Find("Minimap Enemy");
        if (Powerups.SeeEnemiesOnMinimap) minimapIcon.SetActive(true);
        else minimapIcon.SetActive(false);
        health = 3;
        Speed = 6f;
    }

    void Update()
    {
        if (lostVisual) loseInterestCount--;
        if (loseInterestCount <= 0) foundPlayer = false;

        if(foundPlayer) MoveToPlayer();
    }

    void FixedUpdate()
    {
    }

    void MoveToPlayer()
    {//All inputs are handled here
        angleToPlayer = MyMath.PointToPointAngle(rb.position.x, rb.position.y, 
            playerRB.position.x, playerRB.position.y);
        vx = Mathf.Cos(angleToPlayer) * Speed;
        vy = Mathf.Sin(angleToPlayer) * Speed;
        position = rb.position; //set player position to 'position'
        velocity = new Vector2(vx, vy); //set current player velocity to 'velocity'
        position += velocity * Time.fixedDeltaTime; //add velocity to position
        rb.MovePosition(position); //apply position update
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            foundPlayer = true;
            lostVisual = false;
            loseInterestCount = 180;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") lostVisual = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TakeDamage(3);
        }
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(1);
            foundPlayer = true;
        }
    }
}
