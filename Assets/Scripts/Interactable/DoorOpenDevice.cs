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
    public GameObject SFX;

    private Quaternion openRotation;
    private Quaternion closeRotation;

    private bool open = false;

    private void Start()
    {
        openRotation = Quaternion.Euler(0,openAngle,0);
        closeRotation = Quaternion.Euler(0,closeAngle,0);
    }

    public void OpenDoor()
    {
        StartCoroutine(OpenDoorCoroutine());
        
    }

    IEnumerator OpenDoorCoroutine()
    {
        SFX.GetComponent<SoundManager>().playerDoorSound();
        float t = 0f;
        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = initialRotation * Quaternion.Euler(0, openAngle, 0);

        
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
        Quaternion targetRotation = initialRotation * Quaternion.Euler(0, openAngle, 0);

        while (t < 1f)
        {
            t += Time.deltaTime * smoothSpeed;
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, t);
            yield return null;
        }
        open = false;
    }
}
