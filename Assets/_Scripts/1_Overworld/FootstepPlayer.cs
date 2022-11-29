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
    [SerializeField] private AudioClip _clipToPlay;
    [SerializeField] private AudioClip _grassStepClip;
    [SerializeField] private AudioClip _tallGrassStepClip;
    [SerializeField] private AudioClip _pathStepClip;
    [SerializeField] private FootstepSurfaceType _footstepSurfaceType;
    [SerializeField] private bool _isPlaying = false;
    private bool _typeChangedRecently = false;
 
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
        switch (_footstepSurfaceType)
        {
            case FootstepSurfaceType.GRASS:
                _clipToPlay = _grassStepClip;
                break;
            case FootstepSurfaceType.ENCOUNTER_GRASS:
                _clipToPlay = _tallGrassStepClip;
                break;
            case FootstepSurfaceType.PATH:
                _clipToPlay = _pathStepClip;
                break;
            default:
                _clipToPlay = null;
                break;
        }
        if(!_isPlaying)
            StartCoroutine(PlayFootstepOne());
    }

    private IEnumerator PlayFootstepOne()
    {
        _isPlaying = true;
        _audioSource.clip = _clipToPlay;
        _audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        _isPlaying = false;
    }

    private IEnumerator TypeChangeCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        _typeChangedRecently = false;
    }
}
