using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitInput : MonoBehaviour
{
    private Camera _camera;
    private SceneChecker _sceneChecker = new SceneChecker();

    [SerializeField] private PlayerBitMover _playerBitMover;

    [Tooltip("Leave null if bot mode")] [SerializeField]
    private OpponentBitMover _opponentBit;

    private void Start()
    {
        _camera = Camera.main;
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
        if (_sceneChecker.GetLevel() == Level.Bot)
        {
            _playerBitMover.Move(worldTouchPosition, false);
        }
        else
        {
            if (worldTouchPosition.y >= 0)
                _opponentBit.Move(worldTouchPosition);
            else
                _playerBitMover.Move(worldTouchPosition, true);
        }
    }
}