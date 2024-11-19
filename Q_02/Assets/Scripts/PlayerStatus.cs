using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float moveSpeed;


    // ������Ƽ�� �ڱ� �ڽ��� ������ ȣ�� �ϰ� �ִ� 
    // ���� ��Ƶΰų� ���� �� ������ ���� �ʿ�
    public float MoveSpeed
    {
        get => moveSpeed;
        private set => moveSpeed = value;
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        MoveSpeed = 5f;
    }
}
