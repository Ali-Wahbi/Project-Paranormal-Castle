using UnityEngine;

/// <summary>
/// Sound settings, based on SoundSource class settings
/// </summary>

[System.Serializable]
public class Sound
{
    public string name;
    [Header("Sound Settings")]
    public AudioClip clip;
    public SoundType Type;
    public SoundName m_SoundName;

    [Header("Audio Source Settings")]
    [Range(0f, 1f)]
    public float Volume;
    [Range(1f, 3f)]
    public float Pitch = 1;
    public bool Loop;

    [HideInInspector]
    public AudioSource source;
}

/// <summary>
/// Sound type, BackgroundMusic or SFX
/// </summary>
public enum SoundType
{
    BackgroundMusic,
    SFX
}

/// <summary>
/// Used to play a sound by its name, adds extra layer of abstraction
/// to avoid using strings
/// </summary>
public enum SoundName
{
    Wind, ArabMusic, NormalWalking, DoorOpen, DoorClose,
}
/// <summary>
/// Sound Actions: Play, Stop, Pause, Resume
/// </summary>
public enum SoundAction
{
    Play, Stop, Pause, Resume
}

