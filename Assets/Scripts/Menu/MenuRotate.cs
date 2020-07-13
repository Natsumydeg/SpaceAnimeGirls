using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRotate : MonoBehaviour
{
    public float Rotation;
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.y + Rotation, 0);
    }
}
