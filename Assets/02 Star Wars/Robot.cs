using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Move
{
    public GameObject ledakan;
    public GameObject Win;
    private int score;
    public int Health;

    private void Start()
    {
        Health = 100;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            Kanan();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Kiri();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Atas();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Bawah();
        }

        if (score == 5)
        {
            Win.SetActive(true);
        }
    }

    public void OnTriggerEnter(Collider sampah)
    {
        Instantiate(ledakan,sampah.transform.position,sampah.transform.rotation);

        Destroy(sampah.gameObject);
        score = score + 1;
    }
}
