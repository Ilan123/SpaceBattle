using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHit : MonoBehaviour
{
    [SerializeField] GameObject attacker;
    [SerializeField] public float AttackVelocity = 50f;
    [SerializeField]  private Vector3 roationDirection;
    //Start is called before the first frame update
    void Start()
    {
        Vector3 direction = attacker.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = attacker.transform.position;
        Vector3 axis = roationDirection;
        transform.RotateAround(point, axis, Time.deltaTime * AttackVelocity);
    }
}
