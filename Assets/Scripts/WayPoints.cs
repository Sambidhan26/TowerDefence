using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    //[SerializeField]
    //GameObject towerPrefab;
    [SerializeField] bool isPlaceable;
    //private void OnMouseOver()
    //{
    //    Debug.Log(transform.name);
    //}
    public bool IsPlaceable{get{ return isPlaceable;}}

    //public bool GetisPlaceable()
    //{
    //    return isPlaceable;
    //}

    private void Start()
    {
        //towerPrefab = GetComponent<Tower>();
    }
    public void OnMouseDown()
    {
        if(isPlaceable)
        {
            bool isPlaced =  towerPrefab.CreateTower(towerPrefab,transform.position);
            //Instantiate(towerPrefab, transform.position,Quaternion.identity);
            isPlaceable = !isPlaced;
            //Debug.Log(transform.name);

        }
    }
}
