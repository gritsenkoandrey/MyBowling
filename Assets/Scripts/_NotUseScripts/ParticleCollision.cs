using UnityEngine;


public sealed class ParticleCollision : BaseModel
{
    private void OnParticleCollision(GameObject other)
    {
        bot = other.gameObject.GetComponentInParent<BotBase>();

        if (bot)
        {
            //bot.DestroyBotWithParticle();
        }
    }
}