using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alarm
{
    public class AlarmSetup : MonoBehaviour
    {
        [SerializeField] private AlarmView _alarmView;

        private AlarmPresenter _alarmPresenter;
        private AlarmModel _alarmModel;

        private void Awake()
        {
            _alarmModel= new AlarmModel();
            _alarmPresenter = new AlarmPresenter(_alarmModel, _alarmView);
        }

        private void OnEnable()
        {
            _alarmPresenter.Enable();
        }

        private void OnDisable()
        {
            _alarmPresenter.Disable();
        }
    }
}
