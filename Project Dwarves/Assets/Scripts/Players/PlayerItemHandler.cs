using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemHandler : MonoBehaviour
{
    public Transform playerItemSpawnPoint;

    public GameObject heldItem;

    public void HoldNewItem(GameObject itemToHold)
    {
        if (heldItem != null)
            return;

        GameObject _HeldItem = Instantiate(itemToHold, playerItemSpawnPoint);
    }

    public bool IsHoldingItem()
    {
        if (heldItem == null)
        {
            return false;
        }
        else return true;
    }


}

