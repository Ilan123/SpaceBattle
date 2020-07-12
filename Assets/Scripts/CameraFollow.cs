using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    private Vector3 playerStartPos;
    private float playerZDelta;
    private float playerYDelta;
    // Start is called before the first frame update
    void Start()
    {
        playerStartPos = player.position;
        playerZDelta = 0;
        playerYDelta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerZDelta = player.position.z - playerStartPos.z;
        playerYDelta = player.position.y - playerStartPos.y;
        playerStartPos = player.position;
        Vector3 cameraCurrentPos = Camera.main.transform.position;
        cameraCurrentPos.z += playerZDelta;
        cameraCurrentPos.y += playerYDelta;
        Camera.main.transform.position = cameraCurrentPos;

    }
}
