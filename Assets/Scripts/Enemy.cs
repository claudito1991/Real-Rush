using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Waypoint> waypoints = new List<Waypoint>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in waypoints)
        {
            transform.position = waypoint.transform.position + new Vector3(0,5,0);
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
