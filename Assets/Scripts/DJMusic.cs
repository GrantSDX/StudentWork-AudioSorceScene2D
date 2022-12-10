using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _fonSource;
    [SerializeField] private AudioSource _robotSource;
    

    [SerializeField] private AudioClip _fon, _run, _jump, _star;

    private Coroutine _coroutine;

    IEnumerator SoundEnumerator()
    {
        yield return new WaitForSeconds(0.1f);
        _robotSource.PlayOneShot(_run);
    }

    private void Start()
    {
        _fonSource.clip = _fon;
        _fonSource.Play();
        _fonSource.loop = true;
    }

    private void Update()
    {
        if(Input.GetAxis("Horizontal") !=0f || Input.GetAxis("Vertical") != 0f)
        {
            if (_coroutine == null)
                _coroutine = StartCoroutine(SoundEnumerator());
        }
        else
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _coroutine = null;

        }

        if (Input.GetButtonDown("Jump"))
            _robotSource.PlayOneShot(_jump);
    }

    public void PlayStarSound()
    {
        _robotSource.PlayOneShot(_star);
    }
}
