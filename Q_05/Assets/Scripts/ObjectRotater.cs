using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotater : MonoBehaviour
{
    private void Update()
    { 
        // Ÿ�� �������� 0�� �Ǿ Update���� ���ư��� ������ ȸ���� ���� �� ����
        transform.Rotate(Vector3.up * GameManager.Intance.Score);
    }
}
