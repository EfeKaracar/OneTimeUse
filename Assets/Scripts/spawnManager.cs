using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class spawnManager : MonoBehaviour
{
    public List<GameObject> _prefabItems;
    public GameObject[] items;
    public List<GameObject> spawnedItems;
    public GameObject spawnGarbage;
    public List<GameObject> singlePlastics;
    [Header("First Rail")]
    public GameObject LeftSpawn;
    public GameObject RightSpawn;
    public GameObject rail;
    [Header("Second Rail")]
    public GameObject _leftSpawn;
    public GameObject _rightSpawn;
    public GameObject _rail;
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
                GameObject _target = S.GetComponent<itemData>().targetConveyor;
                if(_target == rail) { 
                    float YDistance = (rail.transform.position.y - S.transform.position.y) * -1;
                    if (YDistance <= 1.5) {
                        //Debug.Log(YDistance);
                        if(S.GetComponent<itemData>().onRail == true) { 
                            S.transform.position = Vector3.MoveTowards(S.transform.position, RightSpawn.transform.position, Time.deltaTime * gameBalancing.itemMoveSpeed);
                        }
                    }
                }
                else if(_target == _rail) {
                    float YDistance = (_rail.transform.position.y - S.transform.position.y) * -1;
                    if (YDistance <= 1.5) {
                        //Debug.Log(YDistance);
                        if (S.GetComponent<itemData>().onRail == true) {
                            S.transform.position = Vector3.MoveTowards(S.transform.position, _rightSpawn.transform.position, Time.deltaTime * gameBalancing.itemMoveSpeed);
                        }
                    }
                }
            }
        }
    }
    public void spawnItem() {
        int randomIndex = UnityEngine.Random.Range(0, _prefabItems.Count);
        GameObject O = Instantiate(_prefabItems[randomIndex], LeftSpawn.transform.position, Quaternion.identity);
        spawnedItems.Add(O);
        if(O.GetComponent<itemData>().bin == itemData.bins.single) {
            GameObject C = Instantiate(_prefabItems[randomIndex], spawnGarbage.transform.position, Quaternion.identity);
            singlePlastics.Add(C); }

        if (gameBalancing.activateSecondRail) {
            int _randomIndex = UnityEngine.Random.Range(0, _prefabItems.Count);
            GameObject D = Instantiate(_prefabItems[_randomIndex], _leftSpawn.transform.position, Quaternion.identity);
            spawnedItems.Add(D);
            if (D.GetComponent<itemData>().bin == itemData.bins.single) {
                GameObject C = Instantiate(_prefabItems[randomIndex], spawnGarbage.transform.position, Quaternion.identity);
                singlePlastics.Add(C);
            }
        }
    }

    public Vector3 debugSpawn;
    [ContextMenu("Spawn Items")]
    public void spawnDebug()
    {
        foreach(GameObject P in _prefabItems) {
            Vector3 _pos = new Vector3(debugSpawn.x + Random.Range(-5, 5), debugSpawn.y, debugSpawn.z + Random.Range(-5, +5));
            Instantiate(P, _pos, Quaternion.identity);
        }
    }
}
