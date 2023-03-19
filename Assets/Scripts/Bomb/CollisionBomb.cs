using UnityEngine;

public class CollisionBomb : Bomb
{
    private void OnCollisionEnter(Collision other)
    {
        Explode();
    }
}