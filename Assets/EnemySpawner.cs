using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<DropRatio> spawnEnemy;
    public float interval = 1;
    public float distance = 10;

    IEnumerator Start()
    {
        while (true)
        {
            var enemy = spawnEnemy.OrderBy(x => Random.Range(0, x.ratio))
                .Last().dropGo;
            float angle = Random.Range(0, 360f);
            Quaternion qrot = Quaternion.Euler(0, angle, 0);
            Vector3 pos = qrot * new Vector3(0, 0, distance) + transform.position;
            var newenemy = Instantiate(enemy, pos, Quaternion.identity);

            yield return new WaitForSeconds(interval);
        }
    }
}
