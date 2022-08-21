using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;
    void Awake() => Instance = this;
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
