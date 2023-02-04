using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPool
{
    [SerializeField] private GameObject poolObject;
    [SerializeField] private Transform poolParent;
    [SerializeField] private int initAmount;
    private List<GameObject> pool; public List<GameObject> Pool { get { return pool; } }

    public GameObject GetObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        GameObject obj = AddObjects(pool.Count);
        obj.SetActive(true);
        return obj;
    }

    public GameObject AddObjects()
    {
        pool = new List<GameObject>();
        return AddObjects(initAmount);
    }

    public GameObject AddObjects(int num)
    {
        if (num <= 0)
        {
            if (initAmount <= 0)
            {
                Debug.LogError("Invalid Init Num for Pool: " + this);
                return null;
            }
            return AddObjects(initAmount);
        }

        GameObject obj = null;
        for (int i = 0; i < num; i++)
        {
            obj = Object.Instantiate(poolObject, poolParent);
            obj.SetActive(false);
            pool.Add(obj);
        }
        return obj;
    }

    public void DisableAll()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            pool[i].SetActive(false);
        }
    }

    public void Reset()
    {
        pool = new List<GameObject>();
        AddObjects();
    }
}
