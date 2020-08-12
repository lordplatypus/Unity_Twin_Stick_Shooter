using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : TheRootOfAllEvil
{
    const float Speed = 1;
    Rigidbody2D rb;
    Rigidbody2D playerRB;
    float angleToPlayer;
    float vx;
    float vy;
    Vector2 position;
    Vector2 velocity;
    bool foundPlayer = false;
    GameObject mm;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        mm = GameObject.Find("Minimap Coin");
        if (Powerups.SeeMoneyOnMinimap) mm.SetActive(true);
        else mm.SetActive(false);
    }

    void FixedUpdate()
    {
        if (foundPlayer) MoveToPlayer();
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Wallet.UpdateWallet(1);
            Kill();
        }
        else if (other.gameObject.tag != "Tilemap")  
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), other.gameObject.GetComponent<BoxCollider2D>());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Powerups.MoneyMagnet && other.gameObject.tag == "Player") foundPlayer = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (Powerups.MoneyMagnet && other.gameObject.tag == "Player") foundPlayer = false;
    }
}
