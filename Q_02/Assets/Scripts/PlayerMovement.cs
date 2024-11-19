using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStatus _status;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _status = GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        MovePosition();
    }

    private void MovePosition()
    {
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        if (direction == Vector3.zero) return;
        // 한쪽 키만 입력 했을땐 벡터의 값이 (-)1,0 혹은 (-)0,1을 입력 받게 되지만 동시에 입력 받았을땐 대각선으로 이동하며 (-)1,1이 되어 루트 2가 되기 때문에 벡터의 정규화가 필요
       transform.Translate(_status.MoveSpeed * Time.deltaTime * direction.normalized);
    }
}
