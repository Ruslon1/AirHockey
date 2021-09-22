using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class OpponentBitMover : BitMover
{
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 position)
    {
        base.Move(position, _rigidbody);
    }
}