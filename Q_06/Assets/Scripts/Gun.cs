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
        // ȸ���� ���� ��ǥ�� 0,0,1�� ���� �Ǿ��־� �� �������θ� ���̸� �߻���
        Ray ray = new(origin.position, origin.forward);
        RaycastHit hit;
        // ���̾� ����ũ�� Enemy üũ�� �ȵǾ�����
        if (Physics.Raycast(ray, out hit, _range, _targetLayer))
        {
            Debug.Log($"{hit.transform.name} Hit!!");
        }
    }
    
}
