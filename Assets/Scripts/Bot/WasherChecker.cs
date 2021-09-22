using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bot))]
public class WasherChecker : MonoBehaviour
{
    [SerializeField] private Washer _washer;
    private Bot _bot;
    private float _centerOfScreen => Camera.main.transform.position.y;

    private void Start()
    {
        _bot = GetComponent<Bot>();
    }

    private void Update()
    {
        Check();
    }

    private void Check()
    {
        if (_washer.transform.position.y >= _centerOfScreen)
        {
            if (_bot.CurrentBehavior is PatrolState)
                _bot.SwitchState<PlayState>();
        }

        else
        {
            if (_bot.CurrentBehavior is PlayState)
                _bot.SwitchState<PatrolState>();
        }

    }
}
