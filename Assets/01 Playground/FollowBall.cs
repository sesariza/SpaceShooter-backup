using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public Transform ball;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(ball.position.x, ball.position.y+2, -20);
    }
}
