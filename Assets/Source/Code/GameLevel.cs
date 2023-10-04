using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    [SerializeField] private Transform parentListObj;
    public int countObj;
    public int collectObj;
    private bool canCheck = true;
    
    public List<GameObject> listClaim;
    public void Start()
    {
        canCheck = true;
        foreach (Transform tr in parentListObj)
        {
            listClaim.Add(tr.gameObject);
            countObj++;
        }

        collectObj = 0;
    }

    public void RemoveObject(GameObject obj)
    {
        listClaim.Remove(obj);
        Destroy(obj.gameObject);
        collectObj++;
    }
}
