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
                s.source.loop = s.Loop;

            }

            if (s.Type == SoundType.SFX)
            {

                s.source = SFXGroup.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.Volume;
                s.source.loop = s.Loop;

            }
        }
    }
    private void Start()
    {
        Play(SoundName.Wind);
        Play(SoundName.ArabMusic);
    }

    /// <summary>
    /// Play a sound by its name
    /// </summary>
    /// <param name="soundName">Based on the SoundName Enum</param>
    public void Play(SoundName soundName)
    {
        Sound s = sounds.Find(sound => sound.m_SoundName == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found!");
            return;
        }
        s.source.Play();
    }
}

