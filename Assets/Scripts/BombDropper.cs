using UnityEngine;

public class BombDropper : MonoBehaviour
{
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private float _height;
    void Update()
    {
        //TODO: AddNewInputSystem
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Instantiate(bombPrefab, hitInfo.point + Vector3.up * _height, Quaternion.identity);
            }
        }
    }
}