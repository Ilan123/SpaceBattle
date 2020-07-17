using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolderLogic : MonoBehaviour
{
    private Collider tileCollider;
    private Collider playerHolder;
    private List<GameObject> TilesColided;
    // Start is called before the first frame update
    void Start()
    {
        TilesColided = new List<GameObject>();
        tileCollider = GetComponent<Collider>();
        playerHolder = GameObject.Find("Holder").GetComponent<Collider>();
        //Debug.Log(tileCollider.gameObject.name);
        //Debug.Log(playerHolder.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("FirstIn");
        if (other.tag == "TilePlatform")
        {
            playerHolder.enabled = true;
            TilesColided.Add(other.gameObject);
            //Debug.Log("Added: " + other.gameObject.name);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Something: " + other.gameObject.name + " Tag: " + other.tag, other);
        if (other.tag == "TilePlatform")
        {
            playerHolder.enabled = true;
            if (TilesColided.Contains(other.gameObject))
            {
                TilesColided.Remove(other.gameObject);
                //Debug.Log("Added: " + other.gameObject.name);
            }
            if (TilesColided.Count == 0)
                playerHolder.enabled = false;
            
            /* // For DEBUG
            else
            {
                foreach (GameObject Tile in TilesColided)
                {
                    Debug.Log("Tiles: " + Tile);
                }
                Debug.Log("Count: " + TilesColided.Count);
            }
            */
            /*
            Debug.Log("Out");
            LayerMask tileMask = LayerMask.NameToLayer("Tile");
            Collider[] tiles = Physics.OverlapSphere(transform.position, 4f, tileMask);
            if (tiles.Length == 0)
            {
                playerHolder.enabled = false;
                Debug.Log("IF");
            }
            else
            {
                Debug.Log("Else");
                foreach (Collider tile in tiles)
                {
                    Debug.Log("Tile: " + tile.name);
                }
            }
            */
        }
    }
}
