using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour
{
    //[SerializeField] private Vector3 DoorPos;

    public float openAngle = 90f;
    public float closeAngle = 0f;
    public float smoothSpeed = 2f;

    private Quaternion openRotation;
    private Quaternion closeRotation;

    private bool open = false;

    private void Start()
    {
        openRotation = quaternion.Euler(0,openAngle,0);
        closeRotation = quaternion.Euler(0,closeAngle,0);
    }

    public void OpenDoor()
    {
        StartCoroutine(OpenDoorCoroutine());
    }

    IEnumerator OpenDoorCoroutine()
    {
        float t = 0f;
        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = openRotation;

        while (t < 1f)
        {
            t += Time.deltaTime * smoothSpeed;
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, t);
            yield return null;
        }

        open = true;
    }

    void CloseDoor()
    {
        StartCoroutine(CloseDoorCoroutine());
    }

    IEnumerator CloseDoorCoroutine()
    {
        float t = 0f;
        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = closeRotation;

        while (t < 1f)
        {
            t += Time.deltaTime * smoothSpeed;
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, t);
            yield return null;
        }

        open = false;
    }
}
