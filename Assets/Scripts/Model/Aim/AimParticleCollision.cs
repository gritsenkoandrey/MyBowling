using UnityEngine;


public sealed class AimParticleCollision : BaseModel
{
    private void OnParticleCollision(GameObject other)
    {
        bot = other.gameObject.GetComponentInParent<BotBase>();

        if (bot)
        {
            bot.DestroyBotWithParticle();
        }
    }
}