using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public DropType dropType;
    public int amount = 1;

    private void OnTriggerEnter(Collider other)
    {
        Player player= other.GetComponent<Player>();
        if (player == null)
            return;

        player.GetDropItem(dropType, amount);
        Destroy(gameObject);
    }
}

public enum DropType
{
    AddPoint,
    AddHp
}