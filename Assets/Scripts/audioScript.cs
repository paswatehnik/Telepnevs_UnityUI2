using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Фоновая музыка")]
    [SerializeField] private AudioClip backgroundMusic;
    [Range(0f, 1f)] public float musicVolume = 0.5f;

    [Header("Звуки UI")]
    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private AudioClip dragStartSound;
    [SerializeField] private AudioClip dropSound;
    [Range(0f, 1f)] public float sfxVolume = 0.7f;

    private AudioSource _musicSource;
    private AudioSource _sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _musicSource = gameObject.AddComponent<AudioSource>();
        _sfxSource = gameObject.AddComponent<AudioSource>();

        ConfigureAudioSources();
        PlayBackgroundMusic();
    }

    private void ConfigureAudioSources()
    {
        _musicSource.clip = backgroundMusic;
        _musicSource.loop = true;
        _musicSource.volume = musicVolume;

        _sfxSource.playOnAwake = false;
        _sfxSource.volume = sfxVolume;
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            _musicSource.Play();
        }
    }

    public void PlayButtonClick()
    {
        PlaySFX(buttonClickSound);
    }

    public void PlayDragStart()
    {
        PlaySFX(dragStartSound);
    }

    public void PlayDrop()
    {
        PlaySFX(dropSound);
    }

    private void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            _sfxSource.PlayOneShot(clip);
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        _musicSource.volume = musicVolume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        _sfxSource.volume = sfxVolume;
    }
}