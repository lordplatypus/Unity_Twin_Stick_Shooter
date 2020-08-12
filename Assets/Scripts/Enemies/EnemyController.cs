using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : TheRootOfAllEvil
{
    const float Speed = 6f;
    Rigidbody2D rb;
    Vector2 velocity;
    Vector2 position;
    int health = 3;
    float vx;
    float vy;
    float angleToPlayer;
    GameObject player;
    bool foundPlayer = false;
    GameObject mm;
    int loseInterestCount = 180;
    bool lostVisual = false;
    
    bool hitWall = false;
    Vector2 getAroundWall;
    ContactPoint2D[] contacts;
    int[,] map;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        mm = GameObject.Find("Minimap Enemy");       
        if (Powerups.SeeEnemiesOnMinimap) mm.SetActive(true);
        else mm.SetActive(false);

        //contacts = new ContactPoint2D[10];
    }

    public void PassInformation(int[,] map)
    {
        this.map = map;
    }

    // Update is called once per frame
    void Update()
    {
        if (lostVisual) loseInterestCount--;
        if (loseInterestCount <= 0) foundPlayer = false;
    }
    
    void FixedUpdate()
    {
        // if (hitWall) 
        // {
        //     MoveAroundWall();
        //     int wallCount = 0;
        //     int x = (int)rb.position.x;
        //     int y = (int)rb.position.y;
        //     if (map[x + 1, y] == 1) wallCount++;
        //     if (map[x - 1, y] == 1) wallCount++;
        //     if (map[x, y + 1] == 1) wallCount++;
        //     if (map[x, y - 1] == 1) wallCount++;
        //     if (wallCount >= 2) StuckInCorner(x, y);
        // }
        if (foundPlayer) MoveToPlayer();
    }

    public void FoundPlayer()
    {
        foundPlayer = true;
    }

    void MoveToPlayer()
    {//All inputs are handled here
        angleToPlayer = MyMath.PointToPointAngle(rb.position.x, rb.position.y, 
            player.GetComponent<Rigidbody2D>().position.x, player.GetComponent<Rigidbody2D>().position.y);
        vx = Mathf.Cos(angleToPlayer) * Speed;
        vy = Mathf.Sin(angleToPlayer) * Speed;
        position = rb.position; //set player position to 'position'
        velocity = new Vector2(vx, vy); //set current player velocity to 'velocity'
        position += velocity * Time.fixedDeltaTime; //add velocity to position
        rb.MovePosition(position); //apply position update
    }

    // void MoveAroundWall()
    // {
    //     position = rb.position;
    //     position += getAroundWall * Time.fixedDeltaTime;
    //     rb.MovePosition(position);
    // }

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
        else if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(1);
            foundPlayer = true;
        }
        // else if (other.gameObject.tag == "Tilemap")
        // {
        //     hitWall = true;
        //     print("meh");       
        //     Vector2 distanceToPlayer = player.GetComponent<Rigidbody2D>().position - rb.position;
        //     ContactPoint2D c = other.GetContact(0);

        //     if (getAroundWall.y < Speed && c.normal.x != 0)
        //     {
        //         if (distanceToPlayer.y >= 0)
        //         {//up
        //             getAroundWall += new Vector2(0, Speed);
        //         }
        //         else
        //         {//down
        //             getAroundWall -= new Vector2(0, Speed);
        //         }
        //     }
        //     if (getAroundWall.x < Speed && c.normal.y != 0)
        //     {
        //         if (distanceToPlayer.x >= 0)
        //         {
        //             getAroundWall += new Vector2(Speed, 0);
        //         }
        //         else
        //         {
        //             getAroundWall -= new Vector2(Speed, 0);
        //         }
        //     }
        // }
    }

    // void StuckInCorner(int x, int y)
    // {
    //     bool right = false;
    //     bool left = false;
    //     bool up = false;
    //     bool down = false;

    //     if (map[x + 1, y] == 1) right = true;
    //     if (map[x - 1, y] == 1) left = true;
    //     if (map[x, y + 1] == 1) up = true;
    //     if (map[x, y - 1] == 1) down = true;

    //     Vector2 distanceToPlayer = player.GetComponent<Rigidbody2D>().position - rb.position;

    //     if (right && up)
    //     {
    //         if (distanceToPlayer.x > 0) getAroundWall = new Vector2(0, -Speed);
    //         else getAroundWall = new Vector2(-Speed, 0);
    //     }
    //     else if (right && down)
    //     {
    //         if (distanceToPlayer.x > 0) getAroundWall = new Vector2(0, Speed);
    //         else getAroundWall = new Vector2(-Speed, 0);
    //     }
    //     else if (left && up)
    //     {
    //         if (distanceToPlayer.x > 0) getAroundWall = new Vector2(Speed, 0);
    //         else getAroundWall = new Vector2(0, -Speed);
    //     }
    //     else if (left && down)
    //     {
    //         if (distanceToPlayer.x > 0) getAroundWall = new Vector2(Speed, 0);
    //         else getAroundWall = new Vector2(0, Speed);
    //     }
    // }

    // void OnCollisionExit2D(Collision2D other)
    // {
        
    //     if (other.gameObject.tag == "Tilemap")
    //     {
    //         getAroundWall = Vector2.zero;
    //         hitWall = false;
    //     }
    // }

    public void TakeDamage(int damage)
    {
        if (health <= 0) return;
        health = health - damage;
        if (health <= 0) 
        {
            GameObject.Find("Game").GetComponent<ItemManager>().RandomDropGenerator(position);
            GameObject.Find("Game").GetComponent<EnemyManager>().RemoveDeadEnemies();
            Kill();
        }
    }
}
