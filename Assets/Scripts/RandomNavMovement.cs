using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RandomNavMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    // Start is called before the first frame update
    private async UniTask Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        await Move(this.GetCancellationTokenOnDestroy());
    }

    private async UniTask Move(CancellationToken cancellationToken)
    {
        if(cancellationToken.IsCancellationRequested)
            return;
        _agent.SetDestination(FindRandomPoint.RandomPoint());
        //await UniTask.Delay(200, cancellationToken: cancellationToken);
        
        await UniTask.WaitWhile(
            () =>
            {
                float remainingDistance = _agent.remainingDistance;
                return (remainingDistance == 0 || float.IsInfinity(remainingDistance));
            },
            cancellationToken: cancellationToken);
        
        var time = (_agent.remainingDistance / _agent.speed) * 1.1f;
        //Debug.Log($"time = {time}\n_agent.remDist = {_agent.remainingDistance}\nspeed = {_agent.speed}");
        await UniTask.Delay((int)(time * 1000), cancellationToken: cancellationToken);
        await DestinationCheck(cancellationToken);
    }

    private async UniTask DestinationCheck(CancellationToken cancellationToken)
    {
        if (_agent.remainingDistance < 1.5f)
        {
            await UniTask.Delay(500);
            await Move(cancellationToken);
        }
        else
        {
            var time = (_agent.remainingDistance / _agent.speed) * 1.1f;
            await UniTask.Delay((int)(time * 1000), cancellationToken: cancellationToken);
            await DestinationCheck(cancellationToken);
        }
    }
}
