using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class spawnManager : MonoBehaviour
{
    public List<GameObject> _prefabItems;
    public GameObject[] items;
    public List<GameObject> spawnedItems;
    public List<GameObject> singlePlastics;
    public GameObject LeftSpawn;
    public GameObject RightSpawn;
    public GameObject rail;
    private void Start() {
        
        InvokeRepeating("spawnItem", 1, 2);
    }
    public void loadResources() {
        items = Resources.LoadAll<GameObject>("Items");
        foreach(GameObject I in items) {
            itemData _data = I.GetComponent<itemData>();
            if (gameBalancing.allowFoodForSpawn) { if(_data.bin == itemData.bins.food) { _prefabItems.Add(I); } }
            if (gameBalancing.allowMetalForSpawn) { if(_data.bin == itemData.bins.metal) { _prefabItems.Add(I); } }
            if (gameBalancing.allowRecycleForSpawn) { if(_data.bin == itemData.bins.recycle) { _prefabItems.Add(I); } }
            if (gameBalancing.allowSingleForSpawn) { if(_data.bin == itemData.bins.single) { _prefabItems.Add(I); } }
        }
    }
    private void Update() {
        if (spawnedItems.Count <= 0) return;
        foreach(GameObject S in spawnedItems) {
            if (S != null) { 
                float YDistance = (rail.transform.position.y - S.transform.position.y) * -1;
                if (YDistance <= 1.5) {
                    //Debug.Log(YDistance);
                    if(S.GetComponent<itemData>().onRail == true) { 
                        S.transform.position = Vector3.MoveTowards(S.transform.position, RightSpawn.transform.position, Time.deltaTime * gameBalancing.itemMoveSpeed);
                    }
                }
            }
        }
    }
    public void spawnItem() {
        int randomIndex = UnityEngine.Random.Range(0, _prefabItems.Count);
        GameObject O = Instantiate(_prefabItems[randomIndex], LeftSpawn.transform.position, Quaternion.identity);
        spawnedItems.Add(O);

        if(O.GetComponent<itemData>().bin == itemData.bins.single) { singlePlastics.Add(O); }
    }
}
