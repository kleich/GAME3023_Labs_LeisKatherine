using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private AudioManager() {}
    public static AudioManager Instance { get; private set; }

    [SerializeField] AudioSource _musicSourceA;
    [SerializeField] AudioSource _musicSourceB;
    [SerializeField] AudioSource _transitionMusicSource;

    [Header("Background Tracks - see TrackID enum")]
    [Header("Load as: menu, overworld, encounter(player), encounter(enemy")]
    [Tooltip("See TrackID enum to see the corresponding index.")]
    [SerializeField] List<AudioClip> _bgmList = new List<AudioClip>();
    public enum TrackID
    {
        MainMenu,
        Overworld,
        Encounter_Player,
        Encounter_Enemy,
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(Instance);
        else
        {
            Instance = this;
            SceneManager.sceneLoaded += Instance.OnSceneLoaded;
            SceneManager.sceneUnloaded += Instance.OnSceneUnloaded;
            EncounterEventManager.OnChangeBattleMusic += ChangeBattleMusic;
            DontDestroyOnLoad(gameObject);
        }

        AudioManager[] managers_in_scene = FindObjectsOfType<AudioManager>();
        foreach (var item in managers_in_scene)
        {
            if (item != Instance)
                Destroy(item.gameObject);
        }
    }

    public void PlaySingleBGM(TrackID bgm)
    {
        _musicSourceA.Stop();
        _musicSourceB.Stop();
        _musicSourceA.clip = _bgmList[(int)bgm];
        _musicSourceA.Play();
    }

    public void CrossFadeTo(TrackID transition_to, float duration_seconds = 3.0f)
    {
        AudioSource prev_track = _musicSourceA;
        AudioSource next_track = _musicSourceB;

        if (_musicSourceA.isPlaying)
        {
            prev_track = _musicSourceA;
            next_track = _musicSourceB;
        }
        else if (_musicSourceB.isPlaying)
        {
            prev_track = _musicSourceB;
            next_track = _musicSourceA;
        }

        next_track.clip = _bgmList[(int)transition_to];
        next_track.Play();

        StartCoroutine(CrossFadeCoroutine(prev_track, next_track, duration_seconds));
    }


    private IEnumerator CrossFadeCoroutine(AudioSource prev_track, AudioSource next_track, float duration_seconds)
    {
        float time = 0.0f;
        while (time < duration_seconds)
        {
            float t = time / duration_seconds;
            //Mathf.SmoothStep();
            next_track.volume = t;
            prev_track.volume = 1.0f - t; // as t increases, value - t decreases

            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        prev_track.Stop();
        prev_track.volume = 1.0f;
    }
    private void OnSceneLoaded(Scene new_scene, LoadSceneMode mode)
    {
        _transitionMusicSource.Play();

        if(new_scene.name == "Menu")
        {
            CrossFadeTo(TrackID.MainMenu);
        }

        if (new_scene.name == "Main")
        {
            CrossFadeTo(TrackID.Overworld);
        }

        if (new_scene.name == "Encounter")
        {
            CrossFadeTo(TrackID.Encounter_Player);
        }
    }

    private void OnSceneUnloaded(Scene new_scene)
    {
        if (new_scene.name == "Encounter")
        {
            CrossFadeTo(TrackID.Overworld);
        }
    }

    private void ChangeBattleMusic()
    {
        var event_manager = FindObjectOfType<EncounterEventManager>();
        
        if(event_manager)
        {
            if(event_manager.IsPlayerWinning())
            {
                if(!(_musicSourceA.clip == _bgmList[(int)TrackID.Encounter_Player]) && !(_musicSourceB.clip == _bgmList[(int)TrackID.Encounter_Player]))
                    CrossFadeTo(TrackID.Encounter_Player, 8);
            }
            else
            {
                if (!(_musicSourceA.clip == _bgmList[(int)TrackID.Encounter_Enemy]) && !(_musicSourceB.clip == _bgmList[(int)TrackID.Encounter_Enemy]))
                    CrossFadeTo(TrackID.Encounter_Enemy, 8);
            }
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= Instance.OnSceneLoaded;
        SceneManager.sceneUnloaded -= Instance.OnSceneUnloaded;
        EncounterEventManager.OnChangeBattleMusic -= ChangeBattleMusic;
    }
}
