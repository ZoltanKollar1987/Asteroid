using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;   // For background music
    public AudioSource effectsSource; // For sound effects

    [Header("Settings")]
    [Range(0f, 1f)] public float musicVolume = 1f;
    [Range(0f, 1f)] public float effectsVolume = 1f;

    private void Awake()
    {
        // Singleton pattern to ensure a single instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    // Play a single sound effect
    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            effectsSource.PlayOneShot(clip, effectsVolume);
        }
    }

    // Play or change background music
    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        if (musicSource.clip != clip)
        {
            musicSource.Stop();
            musicSource.clip = clip;
            musicSource.loop = loop;
            musicSource.volume = musicVolume;
            musicSource.Play();
        }
    }

    // Stop background music
    public void StopMusic()
    {
        musicSource.Stop();
    }

    // Update music volume
    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        musicSource.volume = musicVolume;
    }

    // Update effects volume
    public void SetEffectsVolume(float volume)
    {
        effectsVolume = Mathf.Clamp01(volume);
    }
}
