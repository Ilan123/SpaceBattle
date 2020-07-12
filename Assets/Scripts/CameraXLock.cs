using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraXLock : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }
}
