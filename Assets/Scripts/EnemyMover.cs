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

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(FollowPath());
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
    }
}
