using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;
    Animator animator;
    void Awake()
    {
        Instance = this;
        animator = GetComponentInChildren<Animator>();
    }
    public int hp;
    public int point;
    public Text hpText;
    public Text pointText;
    internal void GetDropItem(DropType dropType, int amount)
    {
        switch(dropType)
        {
            case DropType.AddHp: AddHp(amount); break;
            case DropType.AddPoint: AddPoint(amount); break;
        }
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

    private void AddPoint(int amount)
    {
        point += amount;
        pointText.text = point.ToString();
    }

    private void AddHp(int amount)
    {
        hp += amount;
        hpText.text = hp.ToString();
    }
}
