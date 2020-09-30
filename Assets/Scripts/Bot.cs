using Assets.Scripts.DoTween;
using UnityEngine;


namespace Assets.Scripts
{
    public sealed class Bot : MonoBehaviour
    {
        [SerializeField] private GameObject _destroyBotParticle;
        [SerializeField] private GameObject _botCollisionParticle;
        [Range(0.0f, 5.0f), SerializeField] private float _destroyBotByTime = 0.0f;
        private Ball _ball;

        private DoTweenCameraShake _shake;
        private DoTweenShowText _text;

        private void Start()
        {
            _shake = FindObjectOfType<DoTweenCameraShake>();
            _text = FindObjectOfType<DoTweenShowText>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _ball = other.gameObject.GetComponent<Ball>();

            if (_ball)
            {
                Instantiate(_destroyBotParticle, gameObject.transform.position, Quaternion.identity);
                Instantiate(_botCollisionParticle, gameObject.transform.position, Quaternion.identity);

                if (_shake != null)
                    _shake.CreateShake();
                //if (_text != null)
                //    _text.ApplyDamage(gameObject.transform.position, 1.0f);

                Invoke(nameof(DestroyBot), _destroyBotByTime);
            }
        }

        private void DestroyBot()
        {
            Destroy(this.gameObject);
        }
    }
}