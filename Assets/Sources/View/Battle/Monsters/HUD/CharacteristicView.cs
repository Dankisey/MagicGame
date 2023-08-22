using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using Game.Model;

namespace Game.View
{
    public class CharacteristicView : MonoBehaviour
    {
        [SerializeField] private Image _filler;
        [SerializeField] private float _maxChangingDelta;
        [SerializeField] private float _updatingTime;

        private VitalCharacteristic _characteristic;
        private float _currentValue;

        public void Init(VitalCharacteristic characteristic)
        {
            if (_characteristic != null)
                Unsubscribe();
            
            _characteristic = characteristic;
            Subscribe();
        }

        private void OnValueChanged(float value)
        {
            if (this == null)
                return;
            _currentValue = value;
            StartCoroutine(ChangeBarValue());
        }

        private IEnumerator ChangeBarValue()
        {
            var waitForSomeSeconds = new WaitForSeconds(_updatingTime);

            while (_filler.fillAmount != _currentValue)
            {
                _filler.fillAmount = Mathf.MoveTowards(_filler.fillAmount, _currentValue, _maxChangingDelta);

                yield return waitForSomeSeconds;
            }
        }

        private void Subscribe()
        {
            _characteristic.ValueChanged += OnValueChanged;
        }

        private void Unsubscribe() 
        {
            _characteristic.ValueChanged -= OnValueChanged;
        }

        private void OnEnable()
        {
            if (_characteristic != null)
                Subscribe();
        }

        private void OnDisable()
        {
            if (_characteristic != null)
                Unsubscribe();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}