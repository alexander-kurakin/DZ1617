using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDeathBehaviour : IBehaviour
{
    private Enemy _enemy;
    public InstantDeathBehaviour(Enemy enemy)
    { 
        _enemy = enemy;
    }
    public void Enter()
    {
        _enemy.DestroyEnemy();
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
