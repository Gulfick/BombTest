using System;
using TMPro;
using UnityEngine;

public class EnemiesManager: MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private MainUI _mainUI;

    private static Action OnFinish;
    private static Action OnDestroyed;
    
    private static int _enemiesCount;

    private void Start()
    {
        OnFinish += () => _mainUI.FinishLevel();
        OnDestroyed += () => _mainUI.SetTextCount(_enemiesCount);
        FindRandomPoint.SetSize(new Vector2(-10,-10), new Vector2(10,10));
        for (int i = 0; i < _count; i++)
        {
            Instantiate(_prefab, FindRandomPoint.RandomPoint(), Quaternion.identity);
            _enemiesCount++;
        }
    }

    public static void EnemyDestroyed()
    {
        if (--_enemiesCount <= 0)
        {
            OnFinish?.Invoke();
        }

        OnDestroyed?.Invoke();
    }
}
