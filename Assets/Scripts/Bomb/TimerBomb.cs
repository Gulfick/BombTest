using Cysharp.Threading.Tasks;
using UnityEngine;

public class TimerBomb : Bomb
{
    [SerializeField] private float _timeToExplode;
    private async UniTask OnCollisionEnter(Collision other)
    {
        await UniTask.Delay((int) (_timeToExplode * 1000), cancellationToken: this.GetCancellationTokenOnDestroy());
        Explode();
    }
}
