using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public int hp = 3;
    Animator animator;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    internal void SetDamage(int power)
    {
        hp -= power;

        if (hp > 0)
            StartCoroutine(AttackedCo());
        else
            StartCoroutine(DieCo());
    }

    public float dieDelay = 0.5f;
    private IEnumerator DieCo()
    {
        animator.Play("Die");
        yield return new WaitForSeconds(dieDelay);
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
                .Last().dropItem;

            var newDropItem = Instantiate(dropItem);
            newDropItem.transform.position = transform.position
            + new Vector3(Random.Range(0, dropRange)
            , 0, Random.Range(0, dropRange));
        }
    }

    public float AttackedDelay = 0.1f;
    private IEnumerator AttackedCo()
    {
        animator.Play("Attacked");
        // 잠시 붉어 졌다가 원래색으로 되돌리자.
        SpriteRenderer sp = animator.GetComponent<SpriteRenderer>();
        sp.color = Color.red;
        yield return new WaitForSeconds(AttackedDelay);
        sp.color = Color.white;
    }
}
[System.Serializable]
public class DropRatio
{
    public DropItem dropItem;
    public float ratio;
}
