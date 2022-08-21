using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : Attackedable
{
    public int power = 1;
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null)
            return;
        player.SetDamage(power);
    }

    protected override void OnDie()
    {
        Destroy(gameObject);
        DropItem();
    }

    public List<DropRatio> dropItems;
    public int minDropCount = 0;
    public int maxDropCount = 3;
    public float dropRange = 1;
    private void DropItem()
    {
        int dropCount = Random.Range(minDropCount, maxDropCount);
        for (int i = 0; i < dropCount; i++)
        {
            var dropItem = dropItems.OrderBy(x => Random.Range(0, x.ratio))
                .Last().dropGo;

            var newDropItem = Instantiate(dropItem);
            newDropItem.transform.position = transform.position
            + new Vector3(Random.Range(0, dropRange)
            , 0, Random.Range(0, dropRange));
        }
    }
}
[System.Serializable]
public class DropRatio
{
    public GameObject dropGo;
    public float ratio;
}
