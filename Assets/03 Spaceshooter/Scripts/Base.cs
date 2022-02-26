using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float move;

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(transform.position.x + moveHorizontal * Time.deltaTime * 10,
            transform.position.y + moveVertical * Time.deltaTime *10,
            transform.position.z);

        gameObject.transform.position = movement;
    }
}
