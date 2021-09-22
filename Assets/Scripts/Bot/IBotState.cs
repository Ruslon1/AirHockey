using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBotState
{
    void Enter();
    void Update();
    void Exit();
}
