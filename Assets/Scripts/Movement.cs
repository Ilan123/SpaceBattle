using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] public float startSpeed = 2f;
    [SerializeField] private float accelerateToStartSpeedRate = 4f;
    [SerializeField] private float accelerateToCurrentSpeedRate = 4f;
    [SerializeField] private float accelerateToSideRate = 4f;
    private GameObject playerBody;
    [SerializeField] private float sideMoveSensitivity = 0.0005f;
    private float currentSpeed;
    private float targetSpeed;
    private Rigidbody rb;
    public static Movement instance;
    //private Vector3 movmentDirection;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        currentSpeed = 0;
        targetSpeed = startSpeed;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.velocity = Vector3.forward * startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        moveForward();
        //posMoveForward(accelerateToStartSpeedRate);
        //Debug.Log(rb.velocity);
    }

    private void accelerateForward(float accelerateRate)
    {
        //Debug.Log("Accelerate: " + amount);
        rb.AddForce(Vector3.forward * accelerateRate, ForceMode.Acceleration);
    }

    private void posMoveForward(float accelerateRate)
    {
        Vector3 newPos = transform.position;
        if (targetSpeed - currentSpeed > accelerateRate)
        {
            currentSpeed += accelerateRate * Time.deltaTime;
            Debug.Log("First");
        }
        else if (targetSpeed > currentSpeed)
        {
            currentSpeed = targetSpeed;
            Debug.Log("Second");
        }

        newPos.z += currentSpeed * Time.deltaTime;
        Debug.Log(currentSpeed);
        transform.position = newPos;
    }

    /*
    private void accelerateToRight(float amount)
    {
        rb.AddForce(Vector3.right * Mathf.Max(amount * accelerateToSideRate, 0.00001f), ForceMode.Force);
    }

    private void accelerateToLeft(float amount)
    {
        rb.AddForce(Vector3.left * Mathf.Max(amount * accelerateToSideRate, 0.00001f) , ForceMode.Force);
    }
    */
    private void moveForward()
    {
        if (rb.velocity.z < startSpeed)
            accelerateForward(accelerateToStartSpeedRate);
        else if (rb.velocity.z < currentSpeed)
            accelerateForward(accelerateToCurrentSpeedRate);
    }
    public void moveToSide(Vector2 TargetPos)
    {
        float xDeltaBwtweenPlayerAndTargetPos = TargetPos.x - transform.position.x;
        float direction = Mathf.Sign(xDeltaBwtweenPlayerAndTargetPos);
        xDeltaBwtweenPlayerAndTargetPos = Mathf.Abs(xDeltaBwtweenPlayerAndTargetPos);
        Vector3 newPos = transform.position;
        if (xDeltaBwtweenPlayerAndTargetPos > sideMoveSensitivity)
        {
            //float accelerateManipulated = 1 + (Mathf.Abs(xDeltaBwtweenPlayerAndTargetPos) * xDeltaBwtweenPlayerAndTargetPos) * accelerateToSideRate;
            newPos.x += direction * ((xDeltaBwtweenPlayerAndTargetPos + accelerateToSideRate) * Time.deltaTime);
        }
        else if(xDeltaBwtweenPlayerAndTargetPos > sideMoveSensitivity / 10f)
        {
            newPos.x += direction * xDeltaBwtweenPlayerAndTargetPos / 1.5f;
        }
        transform.position = newPos;
    }

    public void ScaleUp(float rate)
    {
        maxSpeed *= rate;
        startSpeed *= rate;
        accelerateToStartSpeedRate *= rate;
        accelerateToCurrentSpeedRate *= rate;
        accelerateToSideRate *= rate;
    }

}
