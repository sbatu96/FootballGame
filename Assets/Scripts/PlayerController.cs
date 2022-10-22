using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerController : MonoBehaviour
{
    public GameObject powerUpIndicator;
    private float powerUpStrength = 15.0f;
    private bool hasPowerup=false;
    GameObject focalPoint;
    Rigidbody rigidBody;
    int speed = 1;
    void Start()
    {
        focalPoint = GameObject.Find("FocalPoint");
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rigidBody.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerUpIndicator.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }

    private IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
}
