using System;
using TMPro;

public static class EnemiesManager
{
    public static Action OnFinish;

    private static int _enemiesCount;
    private static TextMeshProUGUI _text;

    public static void SetTextCount(TextMeshProUGUI text)
    {
        _text = text;
    }

    public static void EnemyCreated()
    {
        _enemiesCount++;
        UpdateTextCount();
    }
    
    public static void EnemyDestroyed()
    {
        if (--_enemiesCount <= 0)
        {
            OnFinish?.Invoke();
        }

        UpdateTextCount();
    }

    private static void UpdateTextCount()
    {
        _text.text = $"{_enemiesCount}";
    }
}
