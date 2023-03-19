using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private GameObject _prefab;

    private void Start()
    {
        FindRandomPoint.SetSize(new Vector2(-10,-10), new Vector2(10,10));
        for (int i = 0; i < _count; i++)
        {
            Instantiate(_prefab, FindRandomPoint.RandomPoint(), Quaternion.identity);
        }
    }
}
