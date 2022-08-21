using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemActivator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        DropItem dropItem= other.GetComponent<DropItem>();
        if (dropItem == null)
            return;
        var moveToPlayer = dropItem.GetComponent<MoveToPlayer>();
        if(moveToPlayer != null)
            moveToPlayer.enabled = true;
    }
}
