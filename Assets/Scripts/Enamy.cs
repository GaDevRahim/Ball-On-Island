using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enamy : MonoBehaviour
{

    float posiYRange = -6.0f;

    Rigidbody enamyRG;
    float speed = 3.0f;
    Vector3 whereLook;
    GameObject player;

    internal static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        enamyRG = GetComponent<Rigidbody>();
        whereLook = new Vector3();
        player = GameObject.Find("Player");
    }

    
    void FixedUpdate()
    {
        if (!PlayerController.gameOver)
        {
            whereLook = (player.transform.position - transform.position).normalized;
            enamyRG.AddForce(whereLook * speed, ForceMode.Impulse);

            if (transform.position.y < posiYRange)
            {
                Destroy(gameObject);
                score++;
            }
        }
    }
}
