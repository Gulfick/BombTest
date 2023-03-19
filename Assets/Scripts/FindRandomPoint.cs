using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class FindRandomPoint
{
    private static Vector2 corner0, corner1;
    
    public static void SetSize(Vector2 corner0, Vector2 corner1)
    {
        FindRandomPoint.corner0 = corner0;
        FindRandomPoint.corner1 = corner1;
    }

    public static Vector3 RandomPoint()
    {
        var point = new Vector3(Random.Range(corner0.x, corner1.x), 0,Random.Range(corner0.y, corner1.y));
        NavMesh.SamplePosition(point, out var hit, Mathf.Infinity, NavMesh.AllAreas);
        return hit.position;
    }
}