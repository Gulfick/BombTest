using TMPro;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private GameObject _levelFinished;
    [SerializeField] private TextMeshProUGUI _textCount;

    public void FinishLevel()
    {
        _levelFinished.SetActive(true);
    }

    public void SetTextCount(int count)
    {
        _textCount.text = $"{count}";
    }
}
