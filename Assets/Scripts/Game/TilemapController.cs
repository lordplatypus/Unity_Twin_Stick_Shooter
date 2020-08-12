using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour
{
    TileReference tr;
    int width = Round.width;
    int height = Round.height;
    int[,] map;
    int floorX;
    int floorY;
    int reqFloorPercent = 50;
    int reqFloorAmount;
    int floorCount;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        MyMath.Init();
        tr = GetComponent<TileReference>();

        map = GenerateArray(width, height);

        floorX = MyMath.Range(1, width - 1);
        floorY = MyMath.Range(1, height - 1);
        reqFloorAmount = ((map.GetUpperBound(1) * map.GetUpperBound(0)) * reqFloorPercent) / 100;
        floorCount = 0;
        map[floorX, floorY] = 0;

        BuildMap();
        RenderMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateMap()
    {
        BuildMap();
        RenderMap();
    }

    public void PlacePlayer()
    {
        Instantiate(player, new Vector2(floorX + .5f, floorY + .5f), Quaternion.identity);
    }

    public void PlaceEnemies()
    {
        GameObject.Find("Game").GetComponent<EnemyManager>().SpawnEnemies(map, floorX, floorY);
    }

    int[,] GenerateArray(int width, int height)
    {//this creates the map array that will be used to tell wiether or not a tile is placed
        //'0' = no tile / '1' = tile
        int[,] map = new int[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {                
                map[x, y] = 1;    
                //print(map[x, y]);            
            }
        }
        return map;
    }

    void RenderMap()
    {//given the map array, this sets tiles if map[x, y] = 1
        for (int x = 0; x < width; x++) 
        {
            for (int y = 0; y < height; y++) 
            {
                // 1 = tile, 0 = no tile
                if (map[x, y] == 1) 
                {
                    tr.tilemap.SetTile(new Vector3Int(x, y, 0), tr.wall); 
                    //print(map[x, y]);
                }
            }
        }
    }

    void UpdateMap()
    {//updates and renders the map if we make changes later on
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                TileBase currentTile = tr.tilemap.GetTile(new Vector3Int(x, y, 0));
                if (map[x, y] == 0)
                {//if map[x, y] = 0 remove the tile, if there was one
                    tr.tilemap.SetTile(new Vector3Int(x, y, 0), null);
                }
                else if (currentTile == null)
                {//if the tile was set to null instead of the map array being updated, update the map
                    map[x, y] = 0;
                }
            }
        }
    }

    void BuildMap()
    {
        while (floorCount < reqFloorAmount)
        {
            //if the tile is blank, stay in the while loop
            //this is to make loading the map faster
            while (map[floorX, floorY] == 0)
            {
                //Determine our next direction
                int randDir = MyMath.Range(0, 4);       
                switch (randDir)
                {
                    //Up
                    case 0: 
                    //Ensure that the edges are still tiles
                    if ((floorY + 1) < height - 1) 
                    {
                        //Move the y up one
                        floorY++;
                    }
                    break;
                    //Down
                    case 1: 
                    //Ensure that the edges are still tiles
                    if ((floorY - 1) > 1)
                    { 
                        //Move the y down one
                        floorY--;
                    }
                    break;
                    //Right
                    case 2: 
                    //Ensure that the edges are still tiles
                    if ((floorX + 1) < width - 1)
                    {
                        //Move the x to the right
                        floorX++;
                    }
                    break;
                    //Left
                    case 3: 
                    //Ensure that the edges are still tiles
                    if ((floorX - 1) > 1)
                    {
                        //Move the x to the left
                        floorX--;
                    }
                    break;
                }
                    
                //if the tile is blank, return to the beggining of the loop
                //this is skip the below code, as running it will be a waste if the tile is blank
                if (map[floorX, floorY] == 0) continue;
                        
                //Change it to a blank tile
                map[floorX, floorY] = 0;
                //Increase floor count
                floorCount++;

                break;                   
            }
        }
    }
}
