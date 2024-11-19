using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateAttack : PlayerState
{
    private float _delay = 2;
    private WaitForSeconds _wait;
    
    public StateAttack(PlayerController controller) : base(controller)
    {
        
    }

    public override void Init()
    {
        _wait = new WaitForSeconds(_delay);
        ThisType = StateType.Attack;
    }

    public override void Enter()
    {
        Controller.StartCoroutine(DelayRoutine(Attack));
    }

    public override void OnUpdate()
    {
        
        Debug.Log("Attack On Update");
    }

    public override void Exit()
    {
        // StateMachine의 ChangeState에 있는 CurrentState.Exit(); 구문과 겹쳐 무한 반복 되고 있어서 스택 오버 플로우가 발생한다
        //Machine.ChangeState(StateType.Idle);
    }

    public void ExitAttackState()
    {
        Machine.ChangeState(StateType.Idle);
    }
    

    private void Attack()
    {
        Collider[] cols = Physics.OverlapSphere(
            Controller.transform.position,
            Controller.AttackRadius
            );

        IDamagable damagable;
        foreach (Collider col in cols)
        {
            // foreach문이 돌아가는중에 적이 제거 될 경우에 빈 오브젝트를 참조하다 에러가 발생, 예외처리가 필요
            damagable = col.GetComponent<IDamagable>();

        
            if(damagable == null)
            {
                continue;
            }
            damagable.TakeHit(Controller.AttackValue);
        }
    }

    public IEnumerator DelayRoutine(Action action)
    {
        yield return _wait;

        Attack();

        ExitAttackState();
    }

}
