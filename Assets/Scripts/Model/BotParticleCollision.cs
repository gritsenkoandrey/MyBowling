using UnityEngine;


public class BotParticleCollision : MonoBehaviour
{
    private BotModel _bot;

    private void OnParticleCollision(GameObject other)
    {
        _bot = other.gameObject.GetComponentInParent<BotModel>();

        if (_bot)
        {
            _bot.DestroyBotParticle();
            _bot.DestroyBot();
        }
    }
}