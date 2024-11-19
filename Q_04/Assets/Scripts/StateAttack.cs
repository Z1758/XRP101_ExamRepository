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
        // StateMachine�� ChangeState�� �ִ� CurrentState.Exit(); ������ ���� ���� �ݺ� �ǰ� �־ ���� ���� �÷ο찡 �߻��Ѵ�
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
            // foreach���� ���ư����߿� ���� ���� �� ��쿡 �� ������Ʈ�� �����ϴ� ������ �߻�, ����ó���� �ʿ�
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
