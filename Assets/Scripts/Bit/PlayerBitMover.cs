using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBitMover : BitMover
{
    private readonly float _centerOfScreen = 0;
    private Rigidbody2D _rigidbody;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 position, bool twoPlayers)
    {
        if (twoPlayers == false)
        {
            if (position.y >= _centerOfScreen)
            {
                MoveHorizontally(position, _rigidbody); ;
            }

            else
            {
                base.Move(position, _rigidbody);
            }
        }
        else
        {
            base.Move(position, _rigidbody);
        }
    }
}