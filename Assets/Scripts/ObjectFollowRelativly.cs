using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollowRelativly : MonoBehaviour
{
    [SerializeField] Transform objectToBeFollowed;
    private Vector3 targetStartPos;
    private Vector3 deltaVector;
    [SerializeField] public bool followX = true;
    [SerializeField] public bool followY = true;
    [SerializeField] public bool followZ = true;
    // Start is called before the first frame update
    void Start()
    {
        targetStartPos = objectToBeFollowed.position;
        deltaVector = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        deltaVector = objectToBeFollowed.position - targetStartPos;
        targetStartPos = objectToBeFollowed.position;
        Vector3 newPos = transform.position;

        if (followX)
            newPos.x += deltaVector.x;
        if (followY)
            newPos.y += deltaVector.y;
        if (followZ)
            newPos.z += deltaVector.z;

        transform.position = newPos;
    }
}
