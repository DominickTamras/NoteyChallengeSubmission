using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaypointData", menuName = "ScriptableObjects/WayPointObject", order = 1)]

public class WaypointData : ScriptableObject
{
    public string name;

    public Transform wayPoint;
}
