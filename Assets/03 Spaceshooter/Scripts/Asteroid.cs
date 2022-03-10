using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float tumble;
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);
        gameController.addScore();


        if (other.tag == "Player")
        {
            gameController.GameOver();
        }
        else
        {
            Destroy(gameObject,1); //Destroy Asteroid
        }
       
        Destroy(other.gameObject);

    }
}
