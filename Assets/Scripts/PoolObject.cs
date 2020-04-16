using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    // Start is called before the first frame update
    // public static PoolObject current;
    public GameObject poolObject;
    public int poolAmount = 20;
    public bool willGrow = true;
    List <GameObject> pooledObjects;
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++){
            GameObject obj = (GameObject)Instantiate(poolObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        } 
    }

    // Update is called once per frame
    public GameObject GetPooledObject(){
        for (int i = 0; i < poolAmount; i++ ){
            if (!pooledObjects[i].activeInHierarchy){
                return pooledObjects[i];
            }
        }
        if (willGrow){
            GameObject obj = (GameObject)Instantiate(poolObject);
            pooledObjects.Add(obj);
            poolAmount = pooledObjects.Count;
            return obj;
        }
        return null;
    }
}
