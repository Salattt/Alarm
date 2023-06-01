using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alarm
{
    public class AlarmModel
    {
        private float _maxVolume = 1;
        private float _minVolume = 0;
        private float _targetTime = 7;

        public float Volume { get; private set; } = 0;
        public bool IsAlarmWorking { get; private set; } = false;

        public event Action VolumeChanged;
        public event Action AlarmConditionChanged;

        public void TurnOn()
        {
            IsAlarmWorking= true;

            AlarmConditionChanged?.Invoke();
        }

        public void TurnOff()
        {
            IsAlarmWorking = false;
        }

        public void ChangeVolume(float deltaTime)
        {
            if (IsAlarmWorking)
            {
                Volume += deltaTime / _targetTime;

                VolumeChanged?.Invoke();

                if(Volume > _maxVolume)
                    Volume = _maxVolume;
            }
            else
            {
                Volume -= deltaTime / _targetTime;

                VolumeChanged.Invoke();

                if (Volume < _minVolume)
                {
                    Volume = _minVolume;

                    AlarmConditionChanged?.Invoke();
                }
            }
        }
    }
}