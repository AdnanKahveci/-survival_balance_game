using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float plSpeed = 3.0f;
    private float powerupStrength = 15;
    private float plVertical;
    private float plHorizontal;
    public bool hasPowerup;

    public GameObject PowerupIndicator;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        plVertical = Input.GetAxis("Vertical");
        plHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(plHorizontal, 0, plVertical);
        playerRb.AddForce(movement * plSpeed);
        PowerupIndicator.gameObject.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            PowerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDownTime());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountDownTime()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        PowerupIndicator.SetActive(false);
    }
}
