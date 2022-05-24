using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public WaypointData pathData;

    public Transform currentWayPoint;

    private void Awake()
    {
        currentWayPoint = Instantiate(pathData.wayPoint); //Gets SO transform data

        currentWayPoint.SetParent(transform); //Sets it
    }
    private void OnDrawGizmos() //Creates visual for trail
    {
        if (currentWayPoint != null)
        {
            foreach (Transform obj in currentWayPoint)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(obj.position, 1f);
            }

            Gizmos.color = Color.blue;

            for (int i = 0; i < currentWayPoint.childCount - 1; i++) 
            {
                Gizmos.DrawLine(currentWayPoint.GetChild(i).position, currentWayPoint.GetChild(i + 1).position); //gets each child from the waypoint hieracrhy. Draws line and connects them 
            }

            Gizmos.DrawLine(currentWayPoint.GetChild(currentWayPoint.childCount - 1).position, currentWayPoint.GetChild(0).position);
        }
    }

    public Transform NextWayPoint(Transform currentPoint)
    {
        
        if(currentPoint == null)
        {
            return currentWayPoint.GetChild(0); // Grabs transform of 1st waypoint
        }

        if (currentPoint.GetSiblingIndex() < currentWayPoint.childCount - 1)
        {
            return currentWayPoint.GetChild(currentPoint.GetSiblingIndex() + 1);
        }

        else
        {
            return currentWayPoint.GetChild(0); //Returns back to first waypoint
        }

    }

   
}
