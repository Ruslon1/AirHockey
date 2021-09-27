using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitInput : MonoBehaviour
{
    private Camera _camera;
    private SceneChecker _sceneChecker = new SceneChecker();

    [SerializeField] private PlayerBitMover _playerBitMover;

    [Tooltip("Leave null if bot mode")]
    [SerializeField]
    private OpponentBitMover _opponentBit;
    private Level _level;

    private void Start()
    {
        _camera = Camera.main;
        _level = _sceneChecker.GetLevel();
    }

    private void Update()
    {
        CheckTouch();
    }

    private void CheckTouch()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 screenTouchPosition = Input.mousePosition;
            Vector3 worldTouchPosition = _camera.ScreenToWorldPoint(screenTouchPosition);
            worldTouchPosition.z = 0;
            HandlingAfterTouch(worldTouchPosition);
        }
    }

    private void HandlingAfterTouch(Vector3 worldTouchPosition)
    {
        Debug.Log(_level);
        if (_level == Level.TwoPlayers)
        {
            if (worldTouchPosition.y >= 0)
                _opponentBit.Move(worldTouchPosition);
            else
                _playerBitMover.Move(worldTouchPosition, true);
        }
        else
        {
            _playerBitMover.Move(worldTouchPosition, false);
        }
    }
}