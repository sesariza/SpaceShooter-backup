using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float stopwatch;
    //[SerializeField]
    public bool tick = false;
    // Update is called once per frame

    private void Start()
    {
        Resettime(); //Reset stopwatch
    }

    void Update()
    {
        tick = false;
        if (Time.time - stopwatch > 0.2f) //Kondisi waktu 1 detik
        {
            tick = true;
            Resettime(); 
        }
    }

    public void Kanan()
    {
        transform.Translate(0.5f, 0, 0);
    }

    public void Kiri()
    {
        transform.Translate(-0.5f, 0, 0);
    }

    public void Atas()
    {
        transform.Translate(0, 0.5f, 0);
    }

    public void Bawah()
    {
        transform.Translate(0, -0.5f, 0);
    }

    void Resettime()
    {
        stopwatch = Time.time;
    }
}
