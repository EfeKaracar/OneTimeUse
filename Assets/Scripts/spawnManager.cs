using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject _prefabItem;
    public List<GameObject> spawnedItems;
    public GameObject LeftSpawn;
    public GameObject RightSpawn;
    public GameObject rail;
    private void Start() {
        InvokeRepeating("spawnItem", 1, 2);
    }

    private void Update() {
        if (spawnedItems.Count <= 0) return;
        foreach(GameObject S in spawnedItems) {
            float YDistance = (rail.transform.position.y - S.transform.position.y) * -1;
            if (YDistance <= 1.5) {
                Debug.Log(YDistance);
                if(S.GetComponent<itemData>().onRail == true) { 
                    S.transform.position = Vector3.MoveTowards(S.transform.position, RightSpawn.transform.position, Time.deltaTime * gameBalancing.itemMoveSpeed);
                }
            }
        }
    }

    public void spawnItem() {
        GameObject O = Instantiate(_prefabItem, LeftSpawn.transform.position, Quaternion.identity);
        spawnedItems.Add(O);
    }
}
