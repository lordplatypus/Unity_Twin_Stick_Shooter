using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : TheRootOfAllEvil
{
    const float Speed = 8.0f;
    public static int health = 3;
    Rigidbody2D rb;
    WeaponManager wm;
    Vector2 velocity;
    Vector2 position;
    Vector2 mousePosition;
    Vector2 arrowPosition;
    float angleToMouse;
    float vx;
    float vy;
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        if(ChallengeManager.OneHitDeath) 
        {
            health = 1;
            CurrentHealth.UpdateHealth();
        }
        rb = GetComponent<Rigidbody2D>();
        wm = GetComponent<WeaponManager>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        MouseInput();

        if (health <= 0) 
        {
            Destroy(this);
            GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Game").GetComponent<PlayerDeathManager>().StartDeathCountDown();
            health = 3;
        }
    }

    void FixedUpdate()
    {
        //HandleInput();
        //MouseInput();
    }

    void HandleInput()
    {//All inputs are handled here
        vx = Input.GetAxis("Horizontal") * Speed;
        vy = Input.GetAxis("Vertical") * Speed;
        position = rb.position; //set player position to 'position'
        velocity = new Vector2(vx, vy); //set current player velocity to 'velocity'
        position += velocity * Time.fixedDeltaTime; //add velocity to position
        rb.MovePosition(position); //apply position update

        if (Input.GetButtonDown("Cheat")) 
        {
            Wallet.UpdateWallet(100);

        }
    }

    void MouseInput()
    {
        // mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // angleToMouse = MyMath.PointToPointAngle(position.x, position.y, mousePosition.x, mousePosition.y);
        // arrowPosition.x = position.x + Mathf.Cos(angleToMouse) * .3f;
        // arrowPosition.y = position.y + Mathf.Sin(angleToMouse) * .3f;
        // GameObject.Find("arrow").GetComponent<ArrowController>().MoveArrow(arrowPosition, angleToMouse);
        if (Input.GetMouseButton(0))
        {
            wm.Shoot(position);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        }
    }

    public void SetStartLocation(int x, int y)
    {
        rb.position = new Vector2(x + .5f, y + .5f);
    }

    static public void TakeDamage(int damage)
    {
        if (health <= 0) return;
        health = health - damage;
        CurrentHealth.UpdateHealth();
    }
}
