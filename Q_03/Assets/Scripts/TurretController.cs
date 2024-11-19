using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform _muzzlePoint;
    [SerializeField] private CustomObjectPool _bulletPool;
    [SerializeField] private float _fireCooltime;
    
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        Init();
    }

    // 리지드바디가 없어서 충돌이 되지 않고 있음
    // OnTriggerEnter는 체크 할 두 객체 중 하나라도 리지드바디가 있어야 함
    // 리지드바디로 인해 총알에 밀리는 경우가 발생 할 수 있으니 터렛의 body에 있는 콜라이더 제거
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Fire(other.transform);
        }
    }

    // 플레이어가 범위 밖으로 나갔을때의 공격 중지가 구현이 안되어 있음
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(_coroutine);
        }
    }


    private void Init()
    {
        _coroutine = null;
        _wait = new WaitForSeconds(_fireCooltime);
        _bulletPool.CreatePool();
    }

    private IEnumerator FireRoutine(Transform target)
    {
        while (true)
        {
            yield return _wait;
            // 플레이어가 죽으면 사격 중지
            if (!target.parent.gameObject.activeSelf)
            {
                break;
            }
            transform.rotation = Quaternion.LookRotation(new Vector3(
                target.position.x,
                0,
                target.position.z)
            );
            
            PooledBehaviour bullet = _bulletPool.TakeFromPool();
            bullet.transform.position = _muzzlePoint.position;
            //총알이 플레이어를 바라보는 회전으로 인해 전방으로 나가지 않음 총알에 muzzlePoint의 회전 값을 줘야함
            bullet.transform.rotation = _muzzlePoint.rotation;
            bullet.OnTaken(target);

            
        }
    }

    private void Fire(Transform target)
    {
        _coroutine = StartCoroutine(FireRoutine(target));
    }
}
