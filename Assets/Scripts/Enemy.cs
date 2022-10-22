using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1;
    Rigidbody enemyRb;
    GameObject playerObj;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (playerObj.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
