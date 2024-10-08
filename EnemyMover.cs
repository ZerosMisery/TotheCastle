using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    Enemy enemy;

    void OnEnable()
    {
        FindPath();
        StartCoroutine(FollowPath());
        ReturnToStart();
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Path"); 

        foreach(GameObject tile in tiles)
        {
            Waypoint waypoint = tile.GetComponent<Waypoint>();
            path.Add(waypoint.GetComponent<Waypoint>());  
            

            if(waypoint != null)
            {
                path.Add(waypoint);
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
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
            travelPercent += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
            yield return new WaitForEndOfFrame();
            }
        }
  
    }
}
