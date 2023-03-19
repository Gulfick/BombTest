using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _bombRadius;

    private static Collider[] _colliders = new Collider[30];
    private void OnCollisionEnter(Collision other)
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
                    enemyTransform.GetComponent<IEnemy>().Destroy();
                }
            }
        }
        Destroy(gameObject);
    }
}