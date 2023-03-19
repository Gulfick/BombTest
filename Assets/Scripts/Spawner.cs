using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _levelFinished;
    [SerializeField] private TextMeshProUGUI _textCount;

    private void Start()
    {
        EnemiesManager.OnFinish += () => _levelFinished.SetActive(true);
        EnemiesManager.SetTextCount(_textCount);
        FindRandomPoint.SetSize(new Vector2(-10,-10), new Vector2(10,10));
        for (int i = 0; i < _count; i++)
        {
            Instantiate(_prefab, FindRandomPoint.RandomPoint(), Quaternion.identity);
            EnemiesManager.EnemyCreated();
        }
    }
}
