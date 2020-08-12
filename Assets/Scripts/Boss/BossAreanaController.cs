using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAreanaController : MonoBehaviour
{
    TileReference tr;
    int width = 50;
    int height = 50;
    int[,] map;

    void Start()
    {
        tr = GetComponent<TileReference>();
        map = new int[width, height];   
    }

    void MakeMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    tr.tilemap.SetTile(new Vector3Int(x, y, 0), tr.wall); 
                }
            }
        }
    }
}
