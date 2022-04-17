using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    GameObject focalPoint;
    float posiYRange = -6.0f;

    Rigidbody playerRG;
    float speed = 5.0f;

    [SerializeField] GameObject powerObj;
    [SerializeField] bool hasPowerUp = false;

    Rigidbody enamyRG;
    Vector3 vectorDirection;
    float powerOfBounce = 150.0f;
    float timeWait = 5.0f;

    internal static bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRG = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void FixedUpdate()
    {
        
        if(transform.position.y < posiYRange)
        {
            gameOver = true;
            Destroy(gameObject);
            Destroy(powerObj);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        playerRG.AddForce(focalPoint.transform.right * horizontalInput * speed, ForceMode.Impulse);

        verticalInput = Input.GetAxis("Vertical");
        playerRG.AddForce(focalPoint.transform.forward * verticalInput * speed, ForceMode.Impulse);

        powerObj.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Power Up"))
        {
            hasPowerUp = true;
            powerObj.gameObject.SetActive(hasPowerUp);
            Destroy(other.gameObject);
            StartCoroutine(TimeToWait());
        }
    }

    IEnumerator TimeToWait()
    {
        yield return new WaitForSeconds(timeWait);
        hasPowerUp = false;
        powerObj.gameObject.SetActive(hasPowerUp);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent("Enamy") && hasPowerUp)
        {
            enamyRG = collision.gameObject.GetComponent<Rigidbody>();
            vectorDirection = enamyRG.transform.position - transform.position;
            enamyRG.AddForce(vectorDirection * powerOfBounce, ForceMode.Impulse);
        }
        else if (collision.gameObject.GetComponent("Enamy") && !hasPowerUp)
        {
            enamyRG = collision.gameObject.GetComponent<Rigidbody>();
            vectorDirection = enamyRG.transform.position - transform.position;
            enamyRG.AddForce(vectorDirection * powerOfBounce / 2.0f, ForceMode.Impulse);
        }
    }
}
