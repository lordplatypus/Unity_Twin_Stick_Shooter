using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : TheRootOfAllEvil
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
    float halfLife;
    bool isBomb = false;
    bool redirection = false;
    bool fireBullet = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        position = rb.position;
        position = GetComponent<Transform>().position;
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), Player.GetComponent<BoxCollider2D>());

        // GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        // foreach (GameObject b in bullets)
        // {
        //     Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), b.GetComponent<BoxCollider2D>());
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (fireBullet) 
        {//this delays the bullet long enough so that the computer has time to set its velocity
            Trajectory();
            fireBullet = false;
        }

        if (redirection && halfLife <= Time.time)
        {
            velocity.x = Mathf.Cos(angle2) * speed2;
            velocity.y = Mathf.Sin(angle2) * speed2;
            rb.AddForce(velocity);
            redirection = false;
        }

        if (lifespan <= Time.time) 
        {//kill the bullet when its lifespan is up
            if (isBomb) Explosion(); //if the weapon is a bomb, explode once the bullets lifespan is up
            Kill();
        }
    }

    void FixedUpdate()
    {
        //Trajectory();
    }

    public void SetPerameters(float speed, float angle, float lifespan)
    {
        this.speed = speed;
        this.angle = angle;
        velocity.x = Mathf.Cos(angle) * speed;
        velocity.y = Mathf.Sin(angle) * speed;
        this.lifespan = lifespan + Time.time;
        fireBullet = true;
    }

    public void SetPerametersExplosion(float speed, float angle, float lifespan)
    {
        isBomb = true;
        this.speed = speed;
        this.angle = angle;
        velocity.x = Mathf.Cos(angle) * speed;
        velocity.y = Mathf.Sin(angle) * speed;
        this.lifespan = lifespan + Time.time;
        fireBullet = true;
    }

    public void SetPerametersRedirection(float speed, float speed2, float angle, float angle2,float lifespan)
    {
        redirection = true;
        this.speed = speed;
        this.speed2 = speed2;
        this.angle = angle;
        this.angle2 = angle2;
        velocity.x = Mathf.Cos(angle) * speed;
        velocity.y = Mathf.Sin(angle) * speed;
        halfLife = lifespan / 2 + Time.time;
        this.lifespan = lifespan + Time.time;
        fireBullet = true;
    }

    void Trajectory()
    {
        rb.AddForce(velocity);
        // position = rb.position; //set player position to 'position'
        // position = GetComponent<Transform>().position;
        // position += velocity * Time.fixedDeltaTime; //add velocity to position
        // rb.MovePosition(position); //apply position update
    }

    void Explosion()
    {
        //position = velocity;
        for (int i = 0; i < 360 / 15; i++)
        {
            position = rb.position;
            position.x += Mathf.Cos((i * 15) * MyMath.Deg2Rad) * .1f;
            position.y += Mathf.Sin((i * 15) * MyMath.Deg2Rad) * .1f;
            GameObject bullet = Instantiate(gameObject, position, Quaternion.identity);
            bullet.GetComponent<BulletController>().SetPerameters(.05f, (i * 15) * MyMath.Deg2Rad, 1);
        }
        Kill();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (Powerups.BouncyBullets)
        {
            velocity = Vector2.Reflect(velocity, other.contacts[0].normal);
            rb.AddForce(velocity);
        }
        else if (isBomb)
        {
            Explosion();
        }
        else if (other.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), other.gameObject.GetComponent<BoxCollider2D>());
        }
        else
        {
            Kill();
        }
    }
}
