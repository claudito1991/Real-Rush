using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Waypoint> waypoints = new List<Waypoint>();
    [SerializeField] float yOffset = 0;
    [SerializeField] [Range(0f,5f)] float speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in waypoints)
        {
            //Ac� defino la posici�n incial, la final y cu�nto me voy a mover entre esos puntos
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position + new Vector3(0, yOffset, 0);
            float travelPercent=0f;

            transform.LookAt(waypoint.transform.position);
            // Con un while defino c�mo incrementar travelPercent.
            while(travelPercent<1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
