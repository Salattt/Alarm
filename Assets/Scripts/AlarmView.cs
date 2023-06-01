using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alarm
{
    [RequireComponent(typeof(AudioSource))]
    
    public class AlarmView : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        public event Action EnteredHomeSpace;
        public event Action ExitedHomeSpace;
        public event Action<float> ChangeVolume;

        private bool _isPlayerInside = false;

        public void OnEnable()
        {
            try
            {
                Validate();
            }
            catch(Exception e) 
            {
                enabled = false;
                throw e;
            }
        }

        private void Update()
        {
            if((_isPlayerInside && _audioSource.volume < 1) || (_isPlayerInside == false && _audioSource.volume > 0))
                ChangeVolume.Invoke(Time.deltaTime);
        }

        public void Validate()
        {
            if (_audioSource == null)
                throw new InvalidOperationException();
        }

        public void SetVolume(float volume)
        {
            _audioSource.volume = volume;
        }

        public void ChangeAlarmCondition(bool isAlarmWorking)
        {
            if(_audioSource.isPlaying != isAlarmWorking)
            {
                if(isAlarmWorking)
                    _audioSource.Play();
                else 
                    _audioSource.Stop();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent(typeof(Player)))
            {
                EnteredHomeSpace.Invoke();
                _isPlayerInside = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.GetComponent(typeof(Player)))
            {
                ExitedHomeSpace.Invoke();
                _isPlayerInside = false;
            }
        }
    }
}
