using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRenderOrder : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, new Vector2(25, 3), Quaternion.identity);
        Instantiate(boss, new Vector2(25, 25), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
