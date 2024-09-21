using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private WaveConfigSO _waveConfigSo;
    private List<Transform> wayPoints;
    private int wayPointIndex = 0;

    private void Start()
    {
        wayPoints = _waveConfigSo.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].position;
    }

    private void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (wayPointIndex < wayPoints.Count)
        {
            Vector3 targetPosition = wayPoints[wayPointIndex].position;
            float delta = _waveConfigSo.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
