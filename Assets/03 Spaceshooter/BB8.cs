using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB8 : Move
{
    int kiri = 0;
    int up = 0;

    // Start is called before the first frame update
    void Update()
    {
        if (kiri < 5)
        {
            
            kiri++;
        }
        else if (up < 5)
        {
            
            up++;
        }
    }

    void OnTriggerEnter(Collider sampah)
    {
        Debug.Log("HIT");
        Destroy(sampah.gameObject);
    }
    
}
