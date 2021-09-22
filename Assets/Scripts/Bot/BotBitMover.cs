using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Extensions;

public class BotBitMover : MonoBehaviour
{
    [SerializeField] private List<PatrolPoint> _patrolPoints;

    public void MoveTo(Vector3 position, float time)
    {
        transform.DOMove(position, time);
    }

    public IEnumerator PatrolMoveHandling()
    {
        PatrolPoint targetPoint;

        while (true)
        {
            float time = 0;
            targetPoint = _patrolPoints[Random.Range(0, _patrolPoints.Count)];
            time.CalculatePathTime(transform.position, targetPoint.transform.position, 2f);
            MoveTo(targetPoint.transform.position, time);
            yield return new WaitUntil(() => transform.position == targetPoint.transform.position);
        }
    }
}