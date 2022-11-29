using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSurface : MonoBehaviour
{
    [SerializeField] FootstepSurfaceType _type;
    FootstepPlayer _footstepPlayer;
    bool _typeChangedRecently;

    private void Start()
    {
        _typeChangedRecently = false;
        _footstepPlayer = FindObjectOfType<FootstepPlayer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "FootstepTypeTrigger" && !_typeChangedRecently)
        {
            _typeChangedRecently = true;
            StartCoroutine(ChangePathType());
        }
    }
    private IEnumerator ChangePathType()
    {
        _footstepPlayer.SetSurfaceType(_type);
        yield return new WaitForEndOfFrame();
        _typeChangedRecently = false;
    }
}
