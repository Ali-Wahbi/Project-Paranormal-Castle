using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotator : MonoBehaviour
{
    public float rotateValue = 10f;
    public float duration = 0.5f;
    public bool reverse = false;

    public void RotateDoor()
    {
        if (reverse)
        {

            // float startRotation = transform.eulerAngles.y;
            // float endRotation = startRotation + rotateValue;
            // SetRotation(endRotation);

            PlaySound(SoundName.DoorClose);
            StartCoroutine(RotateOverTime(rotateValue * -1, duration));
        }
        else
        {

            PlaySound(SoundName.DoorOpen);
            StartCoroutine(RotateOverTime(rotateValue, duration));
        }
    }

    private IEnumerator RotateOverTime(float rotateValue, float duration)
    {
        float elapsedTime = 0f;
        float startRotation = transform.eulerAngles.y;
        float endRotation = startRotation + rotateValue;

        while (elapsedTime < duration)
        {
            float yRotation = Mathf.Lerp(startRotation, endRotation, elapsedTime / duration);
            SetRotation(yRotation);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final rotation is set to the exact end rotation
        SetRotation(endRotation);
    }

    private void SetRotation(float endRotation)
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, endRotation, transform.eulerAngles.z);
    }

    void PlaySound(SoundName soundName)
    {
        AudioManager am = FindAnyObjectByType<AudioManager>();
        if (am) am.SetSoundClip(soundName, SoundAction.Play);
    }
}
