using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject _prefabItem;
    public List<GameObject> spawnedItems;
    public GameObject LeftSpawn;
    public GameObject RightSpawn;
    

    private void Start() {
        InvokeRepeating("spawnItem", 1, 2);
    }

    private void Update() {
        if (spawnedItems.Count <= 0) return;
        foreach(GameObject S in spawnedItems) {
            S.transform.position = Vector3.MoveTowards(S.transform.position, RightSpawn.transform.position, Time.deltaTime * gameBalancing.itemMoveSpeed);
        }
    }

    public void spawnItem() {
        GameObject O = Instantiate(_prefabItem, LeftSpawn.transform.position, Quaternion.identity);
        spawnedItems.Add(O);
    }
}
