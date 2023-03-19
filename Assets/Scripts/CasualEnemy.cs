using UnityEngine;

public class CasualEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] private Collider _collider;
    [SerializeField] private GameObject _parent;
    public void Destroy()
    {
        _collider.enabled = false;
        Destroy(_parent);
    }
}
