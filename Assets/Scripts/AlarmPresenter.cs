using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alarm
{
    public class AlarmPresenter
    {
        private AlarmModel _model;
        private AlarmView _view;

        public AlarmPresenter(AlarmModel model, AlarmView view)
        {
            _model = model;
            _view = view;
        }

        public void Enable()
        {
            _model.VolumeChanged += OnVolumeChanged;
            _model.AlarmConditionChanged += OnAlarmConditionChanged;
            _view.EnteredHomeSpace += OnTurnOn;
            _view.ExitedHomeSpace += OnTurnOff;
            _view.ChangeVolume += ChangeVolume;
        }

        public void Disable()
        {
            _model.VolumeChanged -= OnVolumeChanged;
            _model.AlarmConditionChanged += OnAlarmConditionChanged;
            _view.EnteredHomeSpace -= OnTurnOn;
            _view.ExitedHomeSpace -= OnTurnOff;
        }

        private void OnVolumeChanged()
        {
            _view.SetVolume(_model.Volume);
        }

        private void OnTurnOn()
        {
            _model.TurnOn();
        }

        private void OnTurnOff()
        {
            _model.TurnOff();
        }

        private void OnAlarmConditionChanged()
        {
            _view.ChangeAlarmCondition(_model.IsAlarmWorking);
        }

        private void ChangeVolume(float deltaTime)
        {
            _model.ChangeVolume(deltaTime);
        }
    }
}
