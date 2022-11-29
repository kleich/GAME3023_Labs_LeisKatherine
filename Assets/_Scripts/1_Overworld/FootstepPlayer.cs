using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FootstepSurfaceType
{
    GRASS,
    ENCOUNTER_GRASS,
    PATH,
}

public class FootstepPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _grassStepClip = new List<AudioClip>();
    [SerializeField] private List<AudioClip> _tallGrassStepClip = new List<AudioClip>();
    [SerializeField] private List<AudioClip> _pathStepClip = new List<AudioClip>();
    private FootstepSurfaceType _footstepSurfaceType;
    private bool _isPlaying = false;
 
    private void OnEnable()
    {
        PlayerMovement.OnPlayerMovement += PlayFootstepSound;
    }
    private void OnDisable()
    {
        PlayerMovement.OnPlayerMovement -= PlayFootstepSound;
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _footstepSurfaceType = FootstepSurfaceType.GRASS;
    }

    public void SetSurfaceType(FootstepSurfaceType type)
    {
        _footstepSurfaceType = type;
    }

    public void PlayFootstepSound()
    {
        if (!_isPlaying)
        {
           switch (_footstepSurfaceType)
            {
                case FootstepSurfaceType.GRASS:
                    StartCoroutine(PlayFootstepCoroutine(_grassStepClip));
                    break;
                case FootstepSurfaceType.ENCOUNTER_GRASS:
                    StartCoroutine(PlayFootstepCoroutine(_tallGrassStepClip));
                    break;
                case FootstepSurfaceType.PATH:
                    StartCoroutine(PlayFootstepCoroutine(_pathStepClip));
                    break;
                default:
                    break;
            }

        }
    }

    private IEnumerator PlayFootstepCoroutine(List<AudioClip> clips)
    {
        _isPlaying = true;
        _audioSource.clip = clips[Random.Range(0, clips.Count)];
        _audioSource.Play();
        yield return new WaitForSeconds(0.25f);
        _isPlaying = false;
    }

    public void StopAllFootsteps()
    {
        StopAllCoroutines();
        _isPlaying = false;
        _audioSource.Stop();
    }
}
