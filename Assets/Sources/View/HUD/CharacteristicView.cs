using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using Game.Model;

namespace Game.View
{
    public class CharacteristicView : MonoBehaviour
    {
        [SerializeField] private Image _filler;
        [SerializeField] private Color _fillerColor;
        [SerializeField] private float _maxChangingDelta;
        [SerializeField] private float _updatingTime;

        private VitalCharacteristic _characteristic;
        private float _currentValue;

        public void Init(VitalCharacteristic characteristic)
        {
            _characteristic = characteristic;
            _characteristic.ValueChanged += OnValueChanged;
            _filler.color = _fillerColor;
        }

        private void OnValueChanged(float value)
        {
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

        private void OnDisable()
        {
            _characteristic.ValueChanged -= OnValueChanged;
        }
    }
}