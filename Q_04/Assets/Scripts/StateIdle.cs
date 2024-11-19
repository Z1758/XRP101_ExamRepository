using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateIdle : PlayerState
{
    public StateIdle(PlayerController controller) : base(controller) { }

    public override void Init()
    {
        ThisType = StateType.Idle;
    }

    public override void OnUpdate()
    {
        Debug.Log("Idle On Update");

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Machine.ChangeState(StateType.Attack);
        }
        
    }
}
