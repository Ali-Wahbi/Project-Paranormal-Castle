using System.Collections;
using System.Collections.Generic;

using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private List<Sound> sounds;
    [SerializeField] private GameObject BackgroundMusicGroup;
    [SerializeField] private GameObject SFXGroup;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            if (s.Type == SoundType.BackgroundMusic)
            {
                s.source = BackgroundMusicGroup.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.Volume;
                s.source.pitch = s.Pitch;
                s.source.loop = s.Loop;
            }

            if (s.Type == SoundType.SFX)
            {
                s.source = SFXGroup.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.Volume;
                s.source.pitch = s.Pitch;
                s.source.loop = s.Loop;
            }
        }
    }
    private void Start()
    {
        SetSoundClip(SoundName.Wind, SoundAction.Play);
        SetSoundClip(SoundName.ArabMusic, SoundAction.Play);
    }

    /// <summary>
    /// Set a sound by its name to one of the state
    /// </summary>
    /// <param name="soundName">Based on the SoundName Enum</param>
    /// <param name="soundAction">Based on the SoundAction Enum</param>
    public void SetSoundClip(SoundName soundName, SoundAction soundAction)
    {
        Sound s = sounds.Find(sound => sound.m_SoundName == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found!");
            return;
        }
        switch (soundAction)
        {
            case SoundAction.Play:
                s.source.Play();
                break;
            case SoundAction.Stop:
                s.source.Stop();
                break;
            case SoundAction.Pause:
                s.source.Pause();
                break;
            case SoundAction.Resume:
                s.source.UnPause();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Override method to set a sound by its name to one of the state
    /// </summary>
    /// <param name="soundName">The name of the Sound</param>
    /// <param name="soundAction">Based on the SoundAction Enum</param>
    public void SetSoundClip(string soundName, SoundAction soundAction)
    {
        Sound s = sounds.Find(sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found!");
            return;
        }
        switch (soundAction)
        {
            case SoundAction.Play:
                s.source.Play();
                break;
            case SoundAction.Stop:
                s.source.Stop();
                break;
            case SoundAction.Pause:
                s.source.Pause();
                break;
            case SoundAction.Resume:
                s.source.UnPause();
                break;
            default:
                break;
        }
    }


    public AudioClip GetAudioClip()
    {
        Sound s = sounds.Find(sound => sound.m_SoundName == SoundName.Wind);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + SoundName.Wind + " not found!");
            return null;
        }
        return s.source.clip;
    }
}

