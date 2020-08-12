using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTextController : MonoBehaviour
{
    public void MovePosition(Vector2 position)
    {
        GetComponent<Transform>().transform.position = position;
    }
}
