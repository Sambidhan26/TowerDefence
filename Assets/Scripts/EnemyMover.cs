using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoints> path = new List<WayPoints>();
    [SerializeField]
    [Range(0f, 5f)]
    float speed = 1.0f;

    Enemy enemy;
    // Start is called before the first frame update
    private void OnEnable()
    {
            FindPath();
            ReturnToStart();
            StartCoroutine(FollowPath());
        
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Paths");

        //GameObject[] wayPoints = GameObject.FindGameObjectsWithTag("Paths");
        //foreach(GameObject wayPoint in wayPoints)
        //{
        //    path.Add(wayPoint.GetComponent<WayPoints>());
        //}

        foreach (Transform child in parent.transform)
        {
            WayPoints wayPoint = child.GetComponent<WayPoints>();
            if(wayPoint != null)
            {
                path.Add(wayPoint);

            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        foreach (WayPoints wayPoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = wayPoint.transform.position;
            float travelPercent = 0f;
    
            //Debug.Log(wayPoint.name);
            //transform.position = wayPoint.transform.position;

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.LookAt(endPosition);
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();

            }
            //yield return new WaitForSeconds(1);

        }
        FinishPath();
        //Destroy(gameObject);
    }
}
