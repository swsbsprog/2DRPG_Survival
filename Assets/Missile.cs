using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 5;
    public int power = 1;
    void Update()
    {
        transform.Translate(0, 0,
            speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy == null) 
            return;
        enemy.SetDamage(power);
        Destroy(gameObject);
    }
}
