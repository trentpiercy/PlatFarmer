using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SoilTilemap : MonoBehaviour
{
    private Tilemap soilTiles;

    // Keep track of cells with seeds and water
    private HashSet<Vector3Int> seedCells = new();
    private HashSet<Vector3Int> waterCells = new();

    // Keep track of instantiated saplings so we can destroy them
    // cellPos -> sapling object
    private Dictionary<Vector3Int, GameObject> saplings = new();

    public Tile wateredSoilTile;
    public Tile defaultSoilTile;

    public GameObject saplingPrefab;
    public GameObject treePrefab;

    // Offset to instanitate sapling with
    public Vector3 saplingOffset;
    public Vector3 treeOffset;

    private void Start()
    {
        soilTiles = GetComponent<Tilemap>();
        Debug.Assert(wateredSoilTile != null);
        Debug.Assert(saplingPrefab != null);
        Debug.Assert(treePrefab != null);
    }

    public bool PlantSeed(Vector3 position)
    {
        Vector3Int cell = soilTiles.WorldToCell(position);
        cell.y--;

        if (seedCells.Contains(cell)) 
            return false;
        seedCells.Add(cell);

        Vector3 saplingPos = soilTiles.CellToWorld(cell) + saplingOffset;
        GameObject sapling = Instantiate(saplingPrefab, saplingPos, new Quaternion());
        saplings.Add(cell, sapling);

        TryGrowTree(cell);

        return true;
    }


    public bool WaterSoil(Vector3 position)
    {
        Vector3Int cell = soilTiles.WorldToCell(position);
        cell.y--;

        if (waterCells.Contains(cell))
            return false;
        waterCells.Add(cell);

        soilTiles.SetTile(cell, wateredSoilTile);

        TryGrowTree(cell);

        return true;
    }

    
    private bool TryGrowTree(Vector3Int cell)
    {
        if (seedCells.Contains(cell) && waterCells.Contains(cell))
        {
            seedCells.Remove(cell);
            waterCells.Remove(cell);

            // Remove water
            soilTiles.SetTile(cell, defaultSoilTile);

            // Destroy sapling for this cell
            Destroy(saplings[cell]);

            // Spawn in the tree
            Vector3 realPos = soilTiles.CellToWorld(cell);
            Instantiate(treePrefab, realPos + treeOffset, Quaternion.identity);

            return true;
        }

        return false;
    }
}
