using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipByDirectionX : MonoBehaviour
{
    SpriteRenderer sp;
    IMover mover;
    public bool defaultDirection = true;
    void Start()
    {
        sp = GetComponentInChildren<SpriteRenderer>();
        mover = GetComponent<IMover>();
    }

    void Update()
    {
        //방향에 따라서 sp를 플립하자.
        if (mover.DirectionX < 0)
            sp.flipX = defaultDirection;
        else if (mover.DirectionX > 0)
            sp.flipX = !defaultDirection;
    }
}

interface IMover
{
    float DirectionX { get; }
}