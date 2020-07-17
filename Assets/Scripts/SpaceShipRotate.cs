using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipRotate : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 playerLastPos;
    private int debug_i;
    [SerializeField] private float rotateRate = 5f;
    [SerializeField] private float rotateBackToNormalRate = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        debug_i = 0;
        playerLastPos = transform.position;
        rb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosDelta = transform.position - playerLastPos;
        playerLastPos = transform.position;
        Vector3 playerRotation = transform.eulerAngles;
        Vector3 playerRotationAddons = new Vector3(0, 0, 0);
        Vector3 barrelRotate = new Vector3(0, 0, 0);

        if (playerPosDelta.sqrMagnitude > 0.01f)
        {
            //transform.forward = Vector3.Slerp(transform.forward, rigidbody.velocity.normalized, 10 * Time.deltaTime);
            Vector3 lookPos = transform.position;

            //lookPos.z = + rb.velocity.x - transform.rotation.x;
            if (rb.velocity.z > 0.01f)
            {
                lookPos = rb.velocity - transform.position;
                //transform.LookAt(lookPos);
                //barrelRotate.y = 180;
                barrelRotate.x += playerPosDelta.y * -2f * rotateRate;
            }

        }
        else if (playerPosDelta.y < 0.0001f && rb.velocity.z < 0.001f) // Balancing the ship
        {
            barrelRotate.x -= transform.eulerAngles.x;
        }

        if (Mathf.Abs(playerPosDelta.x) > 0.01f)
            barrelRotate.z += playerPosDelta.x * -1f * rotateRate;
        else if (Mathf.Abs(transform.rotation.z) > 0.001f)
        {
            barrelRotate.z -= (Mathf.Sign(180 - transform.eulerAngles.z) * rotateBackToNormalRate);
        }
        else
        {
            playerRotation = transform.eulerAngles;
            playerRotation.z = 0;
            transform.eulerAngles = playerRotation;
        }

        barrelRotate.y -= transform.eulerAngles.y;
        transform.Rotate(barrelRotate);
        //Debug.Log(debug_i + ": Barrel: " + barrelRotate);
        //Debug.Log(debug_i + ": Velocity: " + rb.velocity);
        //Debug.Log(debug_i + ": Delta: " + playerPosDelta);
        //Debug.Log(debug_i + ": Rotate: " + Mathf.Abs(transform.rotation.z));

        debug_i++;
    }

}


/* This is some script that I wrote for the friend, if you find it here, I probably fogot to delete it :)
 * 
 *     // AI code

    [SerializeField] float movmentSpeed;
    [SerializeField] Transform player;
    [SerializeField] Transform floor;
    public bool hasPlayerFalled;

    private void Awake()
    {
        hasPlayerFalled = false;
    }
    void Update()
    {
        if (!hasPlayerFalled) // push only if the player fall
        {
            Vector3 deltaPos = player.position - transform.position; // we want to know what are the differences between the enemy and the player position.
            Vector3 newPos = transform.position; // this is the new desired position of the enemey, we want the enemy to move toward the player

            if (Mathf.Abs(deltaPos.x) > movmentSpeed)
            { // if we are not close enough to the player on the X axis, move toward it.
                newPos.x += Mathf.Sign(deltaPos.x) * movmentSpeed * Time.deltaTime;
            }
            else
            { // if we are close enough we want to slow and only push
                newPos.x += deltaPos.x / 2f;
            }

            if (Mathf.Abs(deltaPos.z) > 0.1f)
            { // if we are not close enough to the player on the Z axis, move toward it.
                newPos.z += Mathf.Sign(deltaPos.z) * movmentSpeed * Time.deltaTime;
            }
            else
            { // if we are close enough we want to slow and only push
                newPos.x += deltaPos.x / 2f;
            }

        }
    }

    public Vector3 GetPushStardPosition()
    {
        Vector3 playerFloorDeltaPos = floor.position - player.position; // we want to know the relative location of the player to the floor.
        Vector3 playerSize = player.gameObject.GetComponent<Renderer>().bounds.size;
        Vector3 aiSize = gameObject.GetComponent<Renderer>().bounds.size;

        // We canculate the relative new desired position.
        // This is the position that between the player location to the floor center
        // On that direction, we want the closet position that have enough "space" for the player and the AI
        Vector3 desiredPos = player.position + playerFloorDeltaPos.normalized * (playerSize.x / 2.2f + aiSize.x / 2.2f);

        return desiredPos;
    }

    */