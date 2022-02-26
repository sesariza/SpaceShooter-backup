using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Move
{
    Move moving;
    int Arah;

    // Update is called once per frame
    void Start()
    {
        moving = GameObject.Find("Main Camera").GetComponent<Move>();
    }

    void Update()
    {
        if (moving.tick) //Kondisi waktu 1 detik
        {
            Arah = Random.Range(0, 4);

            if (Arah == 0)
            {              
                Kanan();
            }

            if (Arah == 1)
            {
                Kiri();
            }

            if (Arah == 2)
            {
                Atas();
            }

            if (Arah == 3)
            {
                Bawah();
            }

            
        }
    }

}
