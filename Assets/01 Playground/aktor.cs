using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aktor : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(
            transform.position.x + moveHorizontal ,
            transform.position.y ,
            transform.position.z + moveVertical);

        gameObject.transform.position = movement;

        gameObject.transform.rotation = Quaternion.Euler(0, 0 ,- moveHorizontal*45);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.transform.position = new Vector3(
                transform.position.x,
                transform.position.y + 1,
                transform.position.z);
        
        }

    }
}
