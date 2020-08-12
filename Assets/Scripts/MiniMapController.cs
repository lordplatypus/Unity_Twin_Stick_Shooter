using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    GameObject mask;
    // Start is called before the first frame update
    void Start()
    {
        mask = GameObject.Find("Mask");
        mask.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Map")) mask.SetActive(true);
        else mask.SetActive(false);
    }
}
