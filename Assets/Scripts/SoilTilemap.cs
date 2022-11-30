using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SoilTile
{
    public bool isWatered;
    public Seed seed;
    public GameObject sapling;
    public Vector3Int cell;

    public SoilTile(Vector3Int cell)
    {
        this.isWatered = false;
        this.seed = null;
        this.sapling = null;
        this.cell = cell;
    }
}

public class SoilTilemap : MonoBehaviour
{
    private Tilemap soilTilemap;

    // Keep track of soilTiles
    // cellPos -> soilTile object
    private Dictionary<Vector3Int, SoilTile> soilTiles = new();

    public Tile wateredSoilTile;
    public Tile defaultSoilTile;

    private void Start()
    {
        soilTilemap = GetComponent<Tilemap>();
        Debug.Assert(wateredSoilTile != null);
    }

    public SoilTile GetSoilTile(Vector3 position)
    {
        Vector3Int cell = soilTilemap.WorldToCell(position);
        cell.y--;
        if (soilTiles.ContainsKey(cell))
        {
            return soilTiles[cell];
        }
        // Create new SoilTile if not exist
        SoilTile soilTile = new SoilTile(cell);
        soilTiles.Add(cell, soilTile);

        return soilTile;
    }

    public bool PlantSeed(Seed seed, Vector3 position)
    {
        SoilTile soilTile = GetSoilTile(position);

        if (soilTile.sapling)
            return false;
        soilTile.seed = seed;

        Vector3 saplingPos = soilTilemap.CellToWorld(soilTile.cell) + seed.saplingOffset;
        GameObject sapling = Instantiate(seed.saplingPrefab, saplingPos, new Quaternion());
        soilTile.sapling = sapling;

        TryGrowTree(soilTile);

        return true;
    }

    public bool RemoveSeed(Vector3 position)
    {
        SoilTile soilTile = GetSoilTile(position);

        if (soilTile.sapling)
        {
            soilTile.sapling = null;
            soilTile.seed = null;
            return true;
        }

        return false;
    }


    public bool WaterSoil(Vector3 position)
    {
        SoilTile soilTile = GetSoilTile(position);

        if (soilTile.isWatered)
            return false;
        Debug.Log("Watered!");
        soilTile.isWatered = true;

        soilTilemap.SetTile(soilTile.cell, wateredSoilTile);
        TryGrowTree(soilTile);

        return true;
    }


    private bool TryGrowTree(SoilTile soilTile)
    {
        if (soilTile.sapling && soilTile.isWatered)
        {
            Debug.Log("Growing Tree!");

            // Set back to unwatered tile
            soilTile.isWatered = false;
            soilTilemap.SetTile(soilTile.cell, defaultSoilTile);

            // Destroy sapling for this cell
            Destroy(soilTile.sapling);
            soilTile.sapling = null;

            // Spawn in the tree
            Vector3 realPos = soilTilemap.CellToWorld(soilTile.cell);
            Instantiate(soilTile.seed.treePrefab, realPos + soilTile.seed.treeOffset, Quaternion.identity);
            soilTile.seed = null;

            return true;
        }

        return false;
    }
}
