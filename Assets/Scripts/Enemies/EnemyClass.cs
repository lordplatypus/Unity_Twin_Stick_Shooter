using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyClass : TheRootOfAllEvil
{
    protected int[,] map;
    protected GameObject player;
    protected Rigidbody2D rb;
    protected GameObject minimapIcon;
    protected int health = 3;
    protected float Speed = 6f;
    protected bool foundPlayer = false;
    
    //public abstract void Start();

    public virtual void PassInfo(int[,] map)
    {
        this.map = map;
    }

    // public abstract void Update();

    // public abstract void FixedUpdate();

    public virtual void TakeDamage(int damage)
    {
        if (health <= 0) return;
        health = health - damage;
        if (health <= 0) 
        {
            GameObject.Find("Game").GetComponent<ItemManager>().RandomDropGenerator(rb.position);
            GameObject.Find("Game").GetComponent<EnemyManager>().RemoveDeadEnemies();
            Kill();
        }
    }
}
