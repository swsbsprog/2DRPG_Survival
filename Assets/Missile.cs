using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 5;
    void Update()
    {
        transform.Translate(0, 0,
            speed * Time.deltaTime);
    }
}
