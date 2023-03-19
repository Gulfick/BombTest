using UnityEngine;

public class CasualDestroyable : MonoBehaviour, IDestroyable
{
    [SerializeField] private GameObject _parent;
    public void Destroy()
    {
        Destroy(_parent);
        EnemiesManager.EnemyDestroyed();
    }
}
