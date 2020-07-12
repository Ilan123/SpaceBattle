using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColide : MonoBehaviour
{
    [SerializeField] public GameObject explosion;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle_D")
            StartCoroutine(Explode());
    }

    private IEnumerator Explode()
    {
        Instantiate(explosion, transform);
        GameObject.Find("jet").SetActive(false);
        yield return new WaitForSeconds(2f);
        GameManager.instance.Lose();
    }
}
