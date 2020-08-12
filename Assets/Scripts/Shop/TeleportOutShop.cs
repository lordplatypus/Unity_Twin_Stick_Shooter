using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOutShop : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Round.round % 5 == 0) SceneController.GameScene();
            else SceneController.GameScene();
        }
    }
}
