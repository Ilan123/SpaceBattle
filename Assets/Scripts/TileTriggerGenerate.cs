using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTriggerGenerate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TilePlayerCollider")
        {
            MapGenerator.instance.GenerateTile(transform.parent.transform);
            Destroy(gameObject);
        }
    }
}
