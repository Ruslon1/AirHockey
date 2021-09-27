using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Extensions;

public class PlayState : IBotState
{
    private BotBitMover _mover;
    private Washer _washer;
    private float _coefficent;
    private Dictionary<Level, float> _levels  = new Dictionary<Level, float>();

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

        InitLevelDictionary();
        SetCoefficent();
    }

    public void Exit()
    {
        _levels.Clear();
    }

    public void Update()
    {
        MoveHandling();
    }

    private void Validate()
    {
        if (_mover == null)
            throw new ArgumentNullException();
        if (_washer == null)
            throw new ArgumentNullException();
    }

    private void MoveHandling()
    {
        float time = 0f;
        time.CalculatePathTime(_mover.transform.position, _washer.transform.position, _coefficent);
        _mover.MoveTo(_washer.transform.position, time);
    }

    private void SetCoefficent()
    {
        var sceneChecker = new SceneChecker();
        Level level = sceneChecker.GetLevel();
        _coefficent = _levels[level];
    }

    private void InitLevelDictionary()
    {
        _levels.Add(Level.EasyBot, 0.5f);
        _levels.Add(Level.MediumBot, 0.25f);
        _levels.Add(Level.AdvancedBot, 0.1f);
    }
}
