using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : PooledBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _deactivateTime;
    [SerializeField] private int _damageValue;

    private Rigidbody _rigidbody;
    private WaitForSeconds _wait;
    
    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        StartCoroutine(DeactivateRoutine());
    }

    // 충돌이 플레이어의 자식 오브젝트인 body 쪽에서 일어나고 있음
    // body쪽에 콜라이더가 있기 때문에 PlayerController를 찾을수 없기 때문에
    // PlayerController가 있는 player쪽에 콜라이더를 만들고 body의 콜라이더를 제거 하거나
    // GetComponentInParent를 사용해서 부모 객체의 PlayerController를 받아 와야함 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other
                .GetComponentInParent<PlayerController>()
                .TakeHit(_damageValue);
        }
    }

    // 컴포넌트에 리지드바디가 없음
    private void Init()
    {
        _wait = new WaitForSeconds(_deactivateTime);
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Fire()
    {
        _rigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
    }

    private IEnumerator DeactivateRoutine()
    {
        yield return _wait;
        ReturnPool();
    }

    public override void ReturnPool()
    {
        // 재생성 될 때 마다 이전의 velocity 값이 누적 되면서 점점 빨라짐
        // 리지드바디에 가해진 힘을 초기화 해줘야함

        _rigidbody.velocity = Vector3.zero;
        Pool.Push(this);
        gameObject.SetActive(false);
    }

    public override void OnTaken<T>(T t)
    {
        if (!(t is Transform)) return;
        //  LookAt 제거
       
        Fire();
    }
}
