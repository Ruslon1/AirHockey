using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Extensions;

public class BotBitMover : MonoBehaviour
{
    [SerializeField] private List<PatrolPoint> _patrolPoints;
    [SerializeField] private Rigidbody2D _rigidbody;

    public void MoveTo(Vector3 position, float time)
    {
        _rigidbody.DOMove(position, time);
    }

    public IEnumerator PatrolMoveHandling()
    {
        PatrolPoint targetPoint;
        float time = 0;

        while (true)
        {
            targetPoint = _patrolPoints[Random.Range(0, _patrolPoints.Count)];
            time.CalculatePathTime(transform.position, targetPoint.transform.position, 1f);
            MoveTo(targetPoint.transform.position, time);
            yield return new WaitUntil(() => transform.position == targetPoint.transform.position);
        }
    }
}