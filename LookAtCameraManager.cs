using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCameraManager : MonoBehaviour
{
    [SerializeField] private List<TargetObject> targetTransforms;

    private Transform _camTf;

    private void Start()
    {
        _camTf = Camera.main.transform;
    }

    private void LateUpdate()
    {
        foreach (TargetObject tO in targetTransforms)
        {
            if (tO.isUIObject)
            {
                Vector3 position = tO.tf.position;
                Vector3 dirToCamera = (_camTf.position - position).normalized;
                tO.tf.LookAt(position + dirToCamera * -1);
            }
            else
            {
                tO.tf.LookAt(_camTf);
            }
        }
    }

    [Serializable]
    private class TargetObject
    {
        public Transform tf;
        public bool isUIObject;
    }
}