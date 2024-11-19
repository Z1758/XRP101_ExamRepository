using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private CubeController _cubeController;
    private Vector3 _cubeSetPoint;


    // 생명 주기 미스 Instantiate 되기전에 SetCubePosition이 먼저 실행됨
    private void Awake()
    {
        CreateCube();
       
    }

    private void Start()
    {
        SetCubePosition(3, 0, 3);
    }

    private void SetCubePosition(float x, float y, float z)
    {
        _cubeSetPoint.x = x;
        _cubeSetPoint.y = y;
        _cubeSetPoint.z = z;

        // 첫번째 방법
        _cubeController.SetPosition(_cubeSetPoint);



        // 두번째 방법
        /*
        _cubeController.SetPoint= _cubeSetPoint;
        _cubeController.SetPosition();
        */

        // 세번째 방법
        /*
        _cubeController.transform.position = _cubeSetPoint;
        */
    }

    private void CreateCube()
    {
        GameObject cube = Instantiate(_cubePrefab);
        _cubeController = cube.GetComponent<CubeController>();
        _cubeSetPoint = _cubeController.SetPoint;
    }
}
