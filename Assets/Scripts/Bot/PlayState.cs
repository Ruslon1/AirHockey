using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Extensions;

public class PlayState : IBotState
{
    private BotBitMover _mover;
    private Washer _washer;
    public PlayState(BotBitMover mover, Washer washer)
    {
        _mover = mover;
        _washer = washer;
    }
    public void Enter()
    {
        try
        {
            Validate();
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void Exit()
    {

    }

    public void Update()
    {
        float time = 0f;
        time.CalculatePathTime(_mover.transform.position, _washer.transform.position, 0.5f);
        _mover.MoveTo(_washer.transform.position, time);
    }

    private void Validate()
    {
        if (_mover == null)
            throw new ArgumentNullException();
        if (_washer == null)
            throw new ArgumentNullException();
    }
}
