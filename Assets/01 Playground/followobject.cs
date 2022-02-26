using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followobject : MonoBehaviour
{
    public GameObject Ikut;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(
            Ikut.transform.position.x,
            Ikut.transform.position.y,
            gameObject.transform.position.z);
    }
}
