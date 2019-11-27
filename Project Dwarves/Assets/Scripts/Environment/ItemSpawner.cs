using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour, I_Interactable
{
    //Components

    //Variables
    public OreType typeOfItemToSpawn;
    public GameObject itemPrefab;
    PlayerItemHandler playerToGiveItemTo;

    public void OnTriggerEnter(Collider other)
    {
        playerToGiveItemTo = other.GetComponent<PlayerItemHandler>();

        UseInteractable();
    }

    public void UseInteractable()
    {
        if (playerToGiveItemTo.heldItem != null)
        return;

        GameObject _obj = Instantiate(itemPrefab, playerToGiveItemTo.playerItemSpawnPoint);
        _obj.transform.SetParent(playerToGiveItemTo.playerItemSpawnPoint);
        _obj.transform.position = playerToGiveItemTo.playerItemSpawnPoint.position;
        playerToGiveItemTo.heldItem = _obj;
    }
}
