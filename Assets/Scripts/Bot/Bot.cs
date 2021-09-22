using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    private Dictionary<Type, IBotState> _behaviorsMap;
    public IBotState CurrentBehavior { get; private set; }

    [SerializeField] private BotBitMover _mover;
    [SerializeField] private Washer _washer;

    private void Awake()
    {
        InitBehaviors();
        SetBehaviorByDefault();
    }

    private void Update()
    {
        CurrentBehavior?.Update();
    }

    private void InitBehaviors()
    {
        _behaviorsMap = new Dictionary<Type, IBotState>
        {
            [typeof(PatrolState)] = new PatrolState(_mover),
            [typeof(PlayState)] = new PlayState(_mover, _washer)
        };
    }

    private void SetBehavior(IBotState behavior)
    {
        CurrentBehavior?.Exit();

        CurrentBehavior = behavior;
        CurrentBehavior.Enter();
    }

    public void SetBehaviorByDefault()
    {
        SwitchState<PatrolState>();
    }

    private IBotState GetBehavior<T>() where T : IBotState
    {
        var type = typeof(T);
        return _behaviorsMap[type];
    }

    public void SwitchState<T>() where T : IBotState
    {
        var behavior = GetBehavior<T>();
        SetBehavior(behavior);
    }
}
