using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    [SerializeField] public Movement playerMovment;
    public float actualDistance = 1.0f;
    public bool useInitalCameraDistance = false;
    private bool tap;

    // Start is called before the first frame update
    void Start()
    {
        if (useInitalCameraDistance)
        {
            Vector3 toObjectVector = transform.position - Camera.main.transform.position;
            Vector3 linearDistanceVector = Vector3.Project(toObjectVector, Camera.main.transform.forward);
            actualDistance = linearDistanceVector.magnitude;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touches.Length > 0)
        {
            Vector3 touchPosition = Input.touches[0].position;
            touchPosition.z = actualDistance;
            playerMovment.moveToSide(Camera.main.ScreenToWorldPoint(touchPosition));
            //Debug.Log("Touch: " + Camera.main.ScreenToWorldPoint(touchPosition));
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = actualDistance;
            playerMovment.moveToSide(Camera.main.ScreenToWorldPoint(mousePosition));
            //Debug.Log(Camera.main.ScreenToWorldPoint(mousePosition));
        }
    }

}
