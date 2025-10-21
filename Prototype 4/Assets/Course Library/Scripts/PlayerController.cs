using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;  
    public float speed = 5f;
    public bool hasPowerUp = false;
    private float powerUpStrenght = 15.0f;
    public GameObject powerUpIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup"))
        {
            hasPowerUp = true;
            powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(powerUpCountDownRoutine());
        }
       
    }

    IEnumerator powerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("collied with " + collision.gameObject.name + " with powerup set to "+ hasPowerUp);
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrenght,ForceMode.Impulse);
        }
    }
}
