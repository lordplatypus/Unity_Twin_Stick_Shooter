using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingEnemy_Teleport : MonoBehaviour
{
    Transform parentT;
    TeleportEnemyController tec;
    bool teleportCooldown = false;
    float teleportCooldownTimer;
    void Start()
    {
        parentT = gameObject.transform.parent;
        tec = parentT.GetComponent<TeleportEnemyController>();
    }

    void Update()
    {
        if (teleportCooldown && teleportCooldownTimer <= Time.time) 
        {
            teleportCooldown = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!teleportCooldown && other.gameObject.tag == "Bullet")
        {
            teleportCooldown = true;
            Vector2 bulletPosition = other.GetComponent<Rigidbody2D>().position;
            tec.Dodge(bulletPosition);
            teleportCooldownTimer = Time.time + 1;
        }
    }
}
