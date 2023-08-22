using System.Collections;
using UnityEngine;
using System;
using TMPro;

namespace Game.View
{
    public class TextWriter : MonoBehaviour
    {
        [SerializeField][Range(0f,0.5f)] private float _timePerSymbol;
        [SerializeField] private TMP_Text _textHolder;
        private Coroutine _currentCoroutine;
        private string _currentText;

        public bool TextInProgress { get; private set; } = false;

        public event Action Changed;

        public void ChangeText(string newText)
        {
            _currentText = newText;

            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
                _textHolder.text = "";
            }

            _currentCoroutine = StartCoroutine(TextChanging());
        }

        public void SkipAnimation()
        {
            if (_currentCoroutine != null)         
                StopCoroutine(_currentCoroutine);

            TextInProgress = false;
            _textHolder.text = _currentText;
            Changed?.Invoke();
        }

        private IEnumerator TextChanging()
        {
            TextInProgress = true;
            var waitForFixedUpdate = new WaitForFixedUpdate();
            int currentSymbol = 0;
            float timeElapsed = 0f;

            while (currentSymbol < _currentText.Length)
            {
                timeElapsed += Time.deltaTime;
                int symbolsAmount = Mathf.FloorToInt(timeElapsed / _timePerSymbol);
                timeElapsed -= symbolsAmount * _timePerSymbol;
                currentSymbol += symbolsAmount;
                string text = _currentText.Substring(startIndex: 0, currentSymbol);
                text += "<color=#00000000>" + _currentText.Substring(currentSymbol) + "</color>";
                _textHolder.text = text;

                yield return waitForFixedUpdate;
            }

            TextInProgress = false;
            Changed?.Invoke();
        }
    }
}