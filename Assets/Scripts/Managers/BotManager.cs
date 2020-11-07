using System.Collections.Generic;


public static class BotManager
{
    //данный класс не используется

    private static List<BotBase> _botsList;

    static BotManager()
    {
        _botsList = new List<BotBase>();
    }

    public static void AddBotToList(BotBase bot)
    {
        if (!_botsList.Contains(bot))
        {
            _botsList.Add(bot);
            bot.OnDieChange += RemoveBotToList;
        }
    }

    public static void RemoveBotToList(BotBase bot)
    {
        if (!_botsList.Contains(bot))
        {
            return;
        }
        bot.OnDieChange -= RemoveBotToList;
        _botsList.Remove(bot);
    }

    //public static void BotSpawner(BotSpawner botSpawner)
    //{
    //    if (_botsList.Count == 0)
    //    {
    //        botSpawner.SpawnBot();
    //    }
    //}

    public static bool BotDestroyed()
    {
        if (_botsList.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}