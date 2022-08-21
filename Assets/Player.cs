using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Attackedable
{
    public static Player Instance;
    new void Awake()
    {
        base.Awake();
        Instance = this;
    }
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

    protected override void OnDie()
    {
        // todo:움직이지 못하게 하기.
        // 게임 종료 UI표시.
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
