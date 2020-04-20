using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathObject : MonoBehaviour
{
    int timesVisited;
    public GameObject[] neighbours;
    
    public void Visited() {
        timesVisited++;
    }

    public int GetVisitNumber() {
        return timesVisited;
    }
}
