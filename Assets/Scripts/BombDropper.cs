using UnityEngine;

public class BombDropper : MonoBehaviour
{
    [SerializeField] private GameObject _casualBombPrefab, _timerBombPrefab;
    [SerializeField] private float _height;
    void Update()
    {
        //TODO: AddNewInputSystem
        if (Input.GetMouseButtonDown(0))
        {
            DropBomb(_casualBombPrefab);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            DropBomb(_timerBombPrefab);
        }
    }

    private void DropBomb(GameObject bombType)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            Instantiate(bombType, hitInfo.point + Vector3.up * _height, Quaternion.identity);
        }
    }
}