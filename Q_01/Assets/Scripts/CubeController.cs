using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //  ������Ƽ�� ����� ���� set�� private��
    public Vector3 SetPoint { get; set; }

    //ù��° ���
    public void SetPosition()
    {
        transform.position = SetPoint;
    }

    //�ι�° ���
    public void SetPosition(Vector3 vec)
    {
        transform.position = vec;
    }
}
