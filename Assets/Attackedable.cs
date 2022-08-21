using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackedable : MonoBehaviour
{
    Animator animator;
    public int hp;
    protected void Awake()
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
        OnDie();
    }
    protected virtual void OnDie()
    {
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
