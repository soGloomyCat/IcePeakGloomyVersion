using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using Cinemachine;

public class Cameras : MonoBehaviour
{
    [SerializeField] private CreoCamera[] _cameras;
    [SerializeField] private CinemachineVirtualCamera _finisherCamera;

    private CinemachineTrackedDolly _dolly;
    private Dictionary<CameraType, CinemachineVirtualCamera> _list = new Dictionary<CameraType, CinemachineVirtualCamera>();

    private void Awake()
    {
        foreach (CreoCamera creoCamera in _cameras)
            _list.Add(creoCamera.Type, creoCamera.Camera);

        _dolly = _finisherCamera.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTrackedDolly>();
        _dolly.m_PathPosition = 0;
    }

    public void Activate(CameraType type)
    {
        foreach (CreoCamera creoCamera in _cameras)
        {
            if (type == creoCamera.Type)
                creoCamera.Camera.Priority = 20;
            else
                creoCamera.Camera.Priority = 0;
        }

        if (type == CameraType.Finisher)
            StartCoroutine(FinisherCameraMove());
    }

    private IEnumerator FinisherCameraMove()
    {
        float lerp = 0;

        while (lerp < 1)
        {
            yield return null;
            lerp += (Time.deltaTime * .3f);
            _dolly.m_PathPosition = lerp;
        }
    }
}

[Serializable]
public class CreoCamera
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private CameraType _type;

    public CinemachineVirtualCamera Camera => _camera;

    public CameraType Type => _type;
}

public enum CameraType
{
    Player,
    Finisher
}
