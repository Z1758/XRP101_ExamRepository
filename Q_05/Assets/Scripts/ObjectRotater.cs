using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotater : MonoBehaviour
{
    private void Update()
    { 
        // 타임 스케일이 0이 되어도 Update문은 돌아가기 때문에 회전을 막을 수 없음
        transform.Rotate(Vector3.up * GameManager.Intance.Score);
    }
}
