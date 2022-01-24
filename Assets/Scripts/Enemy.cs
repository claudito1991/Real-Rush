using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Waypoint> waypoints = new List<Waypoint>();
    [SerializeField] float yOffset = 0;
    [SerializeField] [Range(0f,5f)] float speed;
    // Start is called before the first frame update
    void OnEnable()
    {
        FindPath();
        GoToStartPosition();
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        waypoints.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();

            if (waypoint != null)
            {
                waypoints.Add(waypoint);
            }
        }
    }

    void GoToStartPosition()
    {
        transform.position = waypoints[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in waypoints)
        {
            //Acá defino la posición incial, la final y cuánto me voy a mover entre esos puntos
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position + new Vector3(0, yOffset, 0);
            float travelPercent=0f;

            transform.LookAt(waypoint.transform.position);
            // Con un while defino cómo incrementar travelPercent.
            while(travelPercent<1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
