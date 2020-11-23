using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    [Header("Parameters")] [SerializeField]
    private int cylindersQuantityRange;

    [SerializeField] private float cylindersDistanceRange;
    [SerializeField] private float cylindersHeightOffset;
    [Range(0, 360)] [SerializeField] private float cylindersRotationRange;

    [Header("Objects")] [SerializeField] private GameObject cylindersPrefab;
    [SerializeField] private GameObject cylindersParent;
    [SerializeField] private GameObject cube;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private float _height;
    private float _distance;
    private float _rotation;

    private List<GameObject> _cylinders;

    private void Awake()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        GenerateCylinders();
        GenerateObjects();
    }

    private void GenerateCylinders()
    {
        for (int i = 0; i < cylindersQuantityRange; i++)
        {
            
            Instantiate(cylindersPrefab, new Vector3(_distance, _height),
                Quaternion.Euler(0, 0, _rotation), cylindersParent.transform);

            _distance = Random.Range(-cylindersDistanceRange, cylindersDistanceRange);
            _height = Random.Range(_height, cylindersHeightOffset + _height);
            _rotation = Random.Range(0, cylindersRotationRange);
            
        }
    }

    private void GenerateObjects()
    {
        var instantiatedCube = Instantiate(cube);
        virtualCamera.Follow = instantiatedCube.transform;

    }
}