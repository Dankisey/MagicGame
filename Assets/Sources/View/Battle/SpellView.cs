using System.Collections;
using UnityEngine;

namespace Game.View
{
    public class SpellView : MonoBehaviour
    {
        [SerializeField][Range(0, 100)] private float _disappearingTimePercentage;
        [SerializeField][Range(0, 100)] private int _disappearingSteps;

        private ParticleSystem[] _particles;
        private Vector3 _direction;
        private Transform _target;
        private bool _disappearingStarted;
        private float _disapperaingTime;
        private float _lifeTime;
        private float _speed;

        public void Init(Transform target, float lifeTime)
        {
            _target = target;
            _lifeTime = lifeTime;
            SetVariables();
        }

        private void SetVariables()
        {
            _particles = GetComponentsInChildren<ParticleSystem>();
            _direction = _target.position - transform.position;
            float angle = -Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            _speed = _direction.magnitude / _lifeTime;
            _direction.Normalize();
            _disapperaingTime = _lifeTime / 100 * _disappearingTimePercentage;
            _disappearingStarted = false;
        }

        private bool TryStartDisappearing()
        {
            if (_disappearingStarted == true)
                return false;

            _disappearingStarted = true;
            StartCoroutine(nameof(Disappear));

            return true;
        }

        private IEnumerator Disappear()
        {
            var waitForSomeSeconds = new WaitForSeconds(_disapperaingTime/(float)_disappearingSteps);
            float alphaDelta = 1f / _disappearingSteps;
            float currentAlpha = 1f;

            while(currentAlpha > 0)
            {
                currentAlpha -= alphaDelta;

                if (currentAlpha < 0)
                    break;

                foreach (var particle in _particles)
#pragma warning disable CS0618 // Тип или член устарел
                    particle.startColor = new Color(particle.startColor.r, particle.startColor.g, particle.startColor.b, currentAlpha);
#pragma warning restore CS0618 // Тип или член устарел

                yield return waitForSomeSeconds;
            }        
        }

        private void Update()
        {
            _lifeTime -= Time.deltaTime;

            if(_lifeTime < 0)
                Destroy(gameObject);

            if (_lifeTime < _disapperaingTime)
                TryStartDisappearing();

            transform.position += _speed * Time.deltaTime * _direction;
        }
    }
}