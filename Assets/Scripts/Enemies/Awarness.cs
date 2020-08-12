using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awarness : MonoBehaviour
{
    EnemyController ec;

    void Start()
    {
        ec = GetComponent<EnemyController>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ec.FoundPlayer();
            Kill();
        }
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
