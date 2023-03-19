using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bomb: MonoBehaviour
{
    [SerializeField] protected float _bombRadius;
    protected static Collider[] _colliders = new Collider[30];
    
    public void Explode()
    {
        var bombPosition = transform.position;
        var size = Physics.OverlapSphereNonAlloc(bombPosition, _bombRadius, _colliders);
        for (int i = 0; i < size; i++)
        {
            var enemyTransform = _colliders[i].transform;
            if(!enemyTransform.CompareTag("Enemy"))
                continue;
            
            var enemyPos = enemyTransform.position;
            var dir = enemyPos - bombPosition;
            Debug.DrawLine(bombPosition, enemyPos, Color.red, 2);

            if (Physics.Raycast(bombPosition, dir, out var hit)) {
                if (hit.transform.CompareTag("Enemy"))
                {
                    enemyTransform.GetComponent<IDestroyable>().Destroy();
                }
            }
        }
        Destroy(gameObject);
    }
}
