using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using Game.Model;

namespace Game.View
{
    public class CharacteristicView : MonoBehaviour
    {
        [SerializeField] private float _maxChangingDelta;
        [SerializeField] private float _updatingTime;
        [SerializeField] private Image _filler;

        protected ShowableCharacteristic Characteristic;
        private float _currentValue;

        public virtual void Init(ShowableCharacteristic characteristic)
        {
            if (Characteristic != null)
                Unsubscribe();
            
            Characteristic = characteristic;
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

        protected virtual void Subscribe()
        {
            Characteristic.ValueChanged += OnValueChanged;
        }

        protected virtual void Unsubscribe() 
        {
            Characteristic.ValueChanged -= OnValueChanged;
        }

        private void OnEnable()
        {
            if (Characteristic != null)
                Subscribe();
        }

        private void OnDisable()
        {
            if (Characteristic != null)
                Unsubscribe();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}