using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDeathBehaviour : IBehaviour
{
    private IKillable _killTarget;
    public InstantDeathBehaviour(IKillable killTarget)
    { 
        _killTarget = killTarget;
    }
    public void Enter()
    {
        _killTarget.Kill();
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
