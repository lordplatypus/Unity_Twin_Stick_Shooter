using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOrder : MonoBehaviour
{
    public enum Render
    {
        Map,
        Player,
        Enemies,
        Items,
        Done,
    }

    public Render render = Render.Map;
    TilemapController tm;

    void Start()
    {
        tm = GameObject.Find("Tilemap").GetComponent<TilemapController>();
    }

    void Update()
    {
        if (render == Render.Map) 
        {
            tm.CreateMap();
            render = Render.Player;
        }
        if (render == Render.Player)
        {
            tm.PlacePlayer();
            render = Render.Enemies;
        }
        if (render == Render.Enemies)
        {
            tm.PlaceEnemies();
            render = Render.Done;
        }
        if (render == Render.Done)
        {
            Destroy(this);
        }
    }
}
