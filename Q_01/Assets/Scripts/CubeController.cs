using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //  프로퍼티를 만들어 놓고 set이 private임
    public Vector3 SetPoint { get; set; }

    //첫번째 방법
    public void SetPosition()
    {
        transform.position = SetPoint;
    }

    //두번째 방법
    public void SetPosition(Vector3 vec)
    {
        transform.position = vec;
    }
}
