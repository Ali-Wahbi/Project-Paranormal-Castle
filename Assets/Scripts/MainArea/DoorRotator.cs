using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotator : MonoBehaviour
{
    public float rotateValue = 10f;
    public float duration = 0.5f;
    public bool reverseRotation = false;
    public bool reverseSound = false;

    public void RotateDoor()
    {
        rotateValue = reverseRotation ? rotateValue * -1 : rotateValue;
        StartCoroutine(RotateOverTime(rotateValue, duration));
        PlaySound(reverseSound ? SoundName.DoorClose : SoundName.DoorOpen);
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
