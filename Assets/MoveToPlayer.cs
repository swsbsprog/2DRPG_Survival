using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour, IMover
{
    float IMover.DirectionX => direction.x;
    public float speed = 2;
    public float acceleration = 0;
    Vector3 direction;
    void Update()
    {
        var playerPos =Player.Instance.transform.position;
        direction =  playerPos - transform.position;
        direction.y = 0;
        direction.Normalize();

        speed += acceleration * Time.deltaTime;
        transform.Translate(speed * Time.deltaTime * direction
            , Space.World);
    }
}
