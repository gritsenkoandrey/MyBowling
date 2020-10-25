using UnityEngine;


public sealed class SpawnController : BaseController, IExecute, IInitialization
{
    private BotSpawner _botSpawner;
    private AimSpawner _aimSpawner;


    public void Initialization()
    {
        _botSpawner = Object.FindObjectOfType<BotSpawner>();
        _aimSpawner = Object.FindObjectOfType<AimSpawner>();
    }

    public void Execute()
    {
        BotManager.BotSpawner(_botSpawner);
        AimManager.AimSpawner(_aimSpawner);
    }
}