using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class PatrolState : IBotState
{
    private BotBitMover _mover;
    public PatrolState(BotBitMover mover)
    {
        _mover = mover;
    }

    public void Enter()
    {
        Debug.Log("Enter");
        try
        {
            Validate();
        }
        catch (Exception e)
        {
            _mover.enabled = false;
            throw e;
        }

        _mover.StartCoroutine(_mover.PatrolMoveHandling());
    }

    public void Update()
    {
    }

    public void Exit()
    {
    }

    private void Validate()
    {
        if (_mover == null)
            throw new ArgumentNullException();
    }
}