using UnityEngine;


public sealed class Platform : BaseModel
{
    [SerializeField] private Transform[] _spawnPoint = null;

    private readonly string[] _bots = { "Bot_cop", "Bot_cowboy", "Bot_Bean_Female", "Bot_Bean_Town_Female" };
    private readonly string[] _aims = { "Tree_1", "Tree_2", "Tree_3", "Tree_4", "Box_1" };

    public void SpawnTargetOnPlatform()
    {
        for (int i = 0; i < _spawnPoint.Length; i++)
        {
            if (Random.Range(0, 2) == 1)
            {
                obj = PoolManager.GetObject(_bots[Random.Range(0, _bots.Length)],
                    _spawnPoint[i].transform.position, Quaternion.identity);
                BotManager.AddBotToList(obj.GetComponent<BotBase>());
            }
            else
            {
                obj = PoolManager.GetObject(_aims[Random.Range(0, _aims.Length)],
                    _spawnPoint[i].transform.position, Quaternion.identity);
                AimManager.AddAimToList(obj.GetComponent<AimBase>());
            }
        }
    }
}