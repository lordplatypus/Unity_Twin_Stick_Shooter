using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public void MoveArrow(Vector2 position, float angle)
    {
        GetComponent<Transform>().transform.position = position;
        GetComponent<Transform>().transform.eulerAngles = Vector3.forward * angle;
    }
}
