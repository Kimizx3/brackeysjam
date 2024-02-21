using UnityEngine;
using System.Collections;

public class DoorOpenDevice : MonoBehaviour
{
    public float openAngle = 90f;
    public float closeAngle = 0f;
    public float smoothSpeed = 2f;
    public GameObject SFX;

    private Quaternion openRotation;
    private Quaternion closeRotation;
    private bool isOpeningOrClosing = false;

    private void Start()
    {
        openRotation = Quaternion.Euler(0, openAngle, 0);
        closeRotation = Quaternion.Euler(0, closeAngle, 0);
    }

    public void OpenDoor()
    {
        if (!isOpeningOrClosing)
        {
            StartCoroutine(OpenDoorCoroutine());
        }
        
    }

    IEnumerator OpenDoorCoroutine()
    {
           
        isOpeningOrClosing = true;
        float t = 0f;
        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = initialRotation * openRotation;

        while (t < 1f)
        {
            t += Time.deltaTime * smoothSpeed;
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, t);
            
            yield return null;
        }

        isOpeningOrClosing = false;
        PlayDoorSoundIfApplicable();
    }

    public void CloseDoor()
    {
        if (!isOpeningOrClosing)
            StartCoroutine(CloseDoorCoroutine());
    }

    IEnumerator CloseDoorCoroutine()
    {
        isOpeningOrClosing = true;
        float t = 0f;
        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = initialRotation * closeRotation;
        

        while (t < 1f)
        {
            t += Time.deltaTime * smoothSpeed;
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, t);
            yield return null;
        }

        isOpeningOrClosing = false;
        PlayDoorSoundIfApplicable();
    }
    private void PlayDoorSoundIfApplicable()
    {
        if (SFX != null && (Quaternion.Angle(transform.rotation, openRotation) < 0.1f || Quaternion.Angle(transform.rotation, closeRotation) < 0.1f))
        {
            SFX.GetComponent<SoundManager>()?.playerDoorSound();
        }
    }

    public bool IsOpen()
    {
        return isOpeningOrClosing || Quaternion.Angle(transform.rotation, openRotation) < 1f;
    }
}

