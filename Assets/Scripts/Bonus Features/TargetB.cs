using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class TargetB : MonoBehaviour
{
    private Rigidbody targetRB;

    private GameManagerB gameManager;

    private float minSpeed = 8;
    private float maxSpeed = 14;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    public ParticleSystem explosionParticle;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerB>();


        targetRB.AddForce(RandomUpwardsForce(),ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque()
            , RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
       
   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Cursor Trail"))
        {
            if (!gameManager.isGamePaused)
            {
                if (gameManager.isGameActive)
                {
                    gameManager.UpdateScore(pointValue);
                }
                Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter()
    {
        Destroy(gameObject);
        if (gameObject.CompareTag("Good"))
        {
            gameManager.UpdateLives(-1);
        }
    }

    Vector3 RandomUpwardsForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
