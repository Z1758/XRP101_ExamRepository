using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _targetLayer;
    
    public void Fire(Transform origin)
    {
        // 회전이 월드 좌표계 0,0,1로 고정 되어있어 그 방향으로만 레이를 발사함
        Ray ray = new(origin.position, origin.forward);
        RaycastHit hit;
        // 레이어 마스크에 Enemy 체크가 안되어있음
        if (Physics.Raycast(ray, out hit, _range, _targetLayer))
        {
            Debug.Log($"{hit.transform.name} Hit!!");
        }
    }
    
}
