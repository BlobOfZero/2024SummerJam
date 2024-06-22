using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
    private List<TileData> tileDatas;

    [SerializeField]
    private Dictionary<TileBase, TileData> dataFromTiles;

    [SerializeField]
    private TileBase iceTile;

    [SerializeField]
    private TileBase nonIceTile;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }

    private void Update()
    {
        //change to if statement for non-ice tile getting hit by ice beam once implemented
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = tilemap.WorldToCell(mousePosition);
            TileBase updatedTile = tilemap.GetTile(gridPosition);
            bool isIced = dataFromTiles[updatedTile].isIced;
            TileData currentTile = dataFromTiles[updatedTile];
            if (updatedTile != isIced)
            {
                TransformToIceTile(gridPosition, currentTile);
                print("At position " + gridPosition + " there is now a ice tile.");
            }            
        }
        if (Input.GetMouseButton(1))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = tilemap.WorldToCell(mousePosition);
            TileBase updatedTile = tilemap.GetTile(gridPosition);
            bool isIced = dataFromTiles[updatedTile].isIced;
            TileData currentTile = dataFromTiles[updatedTile];
            if (updatedTile == isIced)
            {
                TransformToNonIceTile(gridPosition, currentTile);
                print("At position " + gridPosition + " there is now a regular tile.");
            }
        }
    }

    public void TransformToIceTile(Vector3Int position, TileData data)
    {
        if((data.isIced == false) && (data.canBeIced == true)) 
        {
            tilemap.SetTile(position, iceTile);
        }
    }
    public void TransformToNonIceTile(Vector3Int position, TileData data)
    {
        if (data.isIced == true)
        {
            tilemap.SetTile(position, nonIceTile);
        }
    }
}
