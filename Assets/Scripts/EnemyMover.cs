using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0,5)] float speed = 1f;

    Vector3 startPosition;
    Vector3 endPosition;
    float travelPercent = 0f;

    Enemy enemy;

    // Start is called before the first frame update
    void OnEnable()
    {
        FindPath(); 
        ReturnToStart();
       StartCoroutine(FollowPath());
    }

    private void Start()
    {
        enemy= GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach(GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }

    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            startPosition = transform.position;
            endPosition = waypoint.transform.position;
            travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);

                yield return new WaitForEndOfFrame();
            }
        }
        gameObject.SetActive(false);
        enemy.StealGold();
    }
}
