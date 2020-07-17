using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float deltaToGenerateNewTile = 10f;
    [SerializeField] Vector3 generatePosition;
    public static MapGenerator instance; // To be change to get permission only
    [SerializeField] GameObject[] tiles;
    [SerializeField] GameObject[] hardTiles;

    private void Awake()
    {
        MapGenerator.instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    
    public void GenerateTile(Transform previousTileTransform)
    {
        GameObject prefabNewTile;
        if (!GameManager.instance.HasBeenBoosted())
            prefabNewTile = GetRandomEasyTile();
        else
            prefabNewTile = GetRandomHardTile();

        Vector3 prevTileSize = previousTileTransform.Find("Plane").GetComponent<Renderer>().bounds.size;
        
        Vector3 pos = previousTileTransform.position;
        pos.z += prevTileSize.z /2f; // first position scale
        //pos.y -= 0.01f;
        GameObject newTile = Instantiate(prefabNewTile, pos, transform.rotation);

        Vector3 newTileSize = newTile.transform.Find("Plane").GetComponent<Renderer>().bounds.size;
        pos.z += newTileSize.z / 2f;
        newTile.transform.position = pos;

        //Debug.Log("Tile: " + newTile.name + ", prev: " + prevTileSize + ",new: " + newTileSize + ",pos: " + pos);
        //Debug.Log("NNN_Tile: " + newTile.name + ", prev: " + previousTileTransform.Find("Plane").GetComponent<Renderer>().bounds.size + ",new: " + newTile.transform.Find("Plane").GetComponent<Renderer>().bounds.size);

    }

    private GameObject GetRandomEasyTile()
    {
        return tiles[Random.Range(0, tiles.Length)];
    }
    private GameObject GetRandomHardTile()
    {
        return hardTiles[Random.Range(0, tiles.Length)];
    }
}
