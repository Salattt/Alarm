using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Trigger))]
[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{ 
    private Coroutine _changeAlarmVolume;
    private Trigger _trigger;
    private AudioSource _audioSource;
    private float _targetTime = 5;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _trigger = GetComponent<Trigger>();
        _trigger.OnEnterTrigger += OnEnterTrigger;
        _trigger.OnExitTrigger += OnExitTrigger;
    }

    private void OnDisable()
    {
        _trigger.OnEnterTrigger -= OnEnterTrigger;
        _trigger.OnExitTrigger -= OnExitTrigger;
    }

    protected void OnEnterTrigger()
    {
        if (_changeAlarmVolume != null)
            StopCoroutine(_changeAlarmVolume);

        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        _changeAlarmVolume = StartCoroutine(VolumeUp());
    }

    protected void OnExitTrigger()
    {
        if (_changeAlarmVolume != null)
            StopCoroutine(_changeAlarmVolume);

        _changeAlarmVolume = StartCoroutine(VolumeDown());
    }

    private IEnumerator VolumeUp()
    {
        while (_audioSource.volume < 1)
        {
            _audioSource.volume += Time.deltaTime / _targetTime;
            yield return null;
        }
    }

    private IEnumerator VolumeDown()
    {
        while (_audioSource.volume > 0)
        {
            _audioSource.volume -= Time.deltaTime / _targetTime;
            yield return null;
        }

        _audioSource.Stop();
    }
}
