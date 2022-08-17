using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnima : MonoBehaviour
{
    [SerializeField] Vector3 vec;
    void Update()
    {
        transform.Rotate(vec * Time.deltaTime);
    }
}
