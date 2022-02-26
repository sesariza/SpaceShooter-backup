using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola : MonoBehaviour
{
    Vector3 spawn = new Vector3(-2, 20, 0);

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -10)
        {
            gameObject.transform.position = spawn;
        }
    }
}
