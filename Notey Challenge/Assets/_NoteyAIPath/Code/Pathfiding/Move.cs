using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Waypoints wayPoints;

    public float moveSpeed;

    private Transform mCurrentWaypoint;

    private float distanceCompare = 0.1f;



    private void Awake()
    {
        //Start waypoint
        mCurrentWaypoint = wayPoints.NextWayPoint(mCurrentWaypoint);
        transform.position = mCurrentWaypoint.position;

        //Waypoint target
        mCurrentWaypoint = wayPoints.NextWayPoint(mCurrentWaypoint);
        transform.LookAt(mCurrentWaypoint);

    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, mCurrentWaypoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, mCurrentWaypoint.position) < distanceCompare)
        {
            mCurrentWaypoint = wayPoints.NextWayPoint(mCurrentWaypoint);
            transform.LookAt(mCurrentWaypoint);


        }
    }
}
