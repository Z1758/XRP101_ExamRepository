using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private CubeController _cubeController;
    private Vector3 _cubeSetPoint;


    // ���� �ֱ� �̽� Instantiate �Ǳ����� SetCubePosition�� ���� �����
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

        // ù��° ���
        _cubeController.SetPosition(_cubeSetPoint);



        // �ι�° ���
        /*
        _cubeController.SetPoint= _cubeSetPoint;
        _cubeController.SetPosition();
        */

        // ����° ���
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
