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
            if (rb.velocity.z > 0.010f)
            {
                lookPos = rb.velocity - transform.position;
                //transform.LookAt(lookPos);
                //barrelRotate.y = 180;
                barrelRotate.x += playerPosDelta.y * -2f * rotateRate;
            }

        }

        if (Mathf.Abs(playerPosDelta.x) > 0.1f)
            barrelRotate.z += playerPosDelta.x * -1f * rotateRate;
        else if (Mathf.Abs(transform.rotation.z) > 0.01f)
        {
            barrelRotate.z -= (Mathf.Sign(180 - transform.eulerAngles.z) * rotateBackToNormalRate);
        }
        else {
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
