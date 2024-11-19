using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float moveSpeed;


    // 프로퍼티가 자기 자신을 무한정 호출 하고 있다 
    // 값을 담아두거나 리턴 할 변수가 따로 필요
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
