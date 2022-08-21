using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MissileSpawner : MonoBehaviour
{
    public Missile missile;
    public float interval = 1;
    HashSet<Enemy> enemies = new();

    IEnumerator Start()
    {
        while (true)
        {
            // 가장 가까이 있는 적에게 미사일을 바라보자.
            var myPos = transform.position;
            var nearnestEnemy = enemies
                .Where(x => x.hp > 0)
                .OrderBy(x => Vector3.Distance(x.transform.position, myPos))
                .FirstOrDefault();
            if (nearnestEnemy != null)
            {
                var newMissile = Instantiate(missile);
                var enemyDir = nearnestEnemy.transform.position - myPos;
                enemyDir.y = 0;

                newMissile.transform.position = myPos;
                //nearnestEnemy <- 이쪽을 바라보자.
                newMissile.transform.forward = enemyDir;
            }
            yield return new WaitForSeconds(interval);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy == null)
            return;
        enemies.Add(enemy);
    }

    private void OnTriggerExit(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        enemies.Remove(enemy);
    }
}
