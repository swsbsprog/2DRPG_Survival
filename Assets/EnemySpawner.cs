using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;

    public float interval = 1;
    public float distance = 10;

    IEnumerator Start()
    {
        while (true)
        {
            float angle = Random.Range(0, 360f);
            Quaternion qrot = Quaternion.Euler(0, angle, 0);
            Vector3 pos = qrot * new Vector3(0, 0, distance) + transform.position;
            var newenemy = Instantiate(enemy, pos, Quaternion.identity);

            yield return new WaitForSeconds(interval);
        }
    }
}
