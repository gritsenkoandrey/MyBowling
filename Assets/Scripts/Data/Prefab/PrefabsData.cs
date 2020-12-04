using UnityEngine;


[CreateAssetMenu(fileName = "PrefabData", menuName = "Data/Prefab/PrefabData")]
public class PrefabsData : ScriptableObject
{
    //platform
    public readonly string[] smallPrefab = { "Small_01", "Small_02", "Small_03", "Small_04", "Small_05", "Small_06", "Small_07", "Small_08", "Small_09", "Small_10", "Small_11", "Small_12", "Small_13", "Small_14", "Small_15", "Small_16" };
    public readonly string[] midlePrefab = { "Midle_01", "Midle_02", "Midle_03", "Midle_04", "Midle_05", "Midle_06", "Midle_07", "Midle_08", "Midle_09", "Midle_10" };
    public readonly string[] longPrefab = { "Long_01", "Long_02", "Long_03", "Long_04", "Long_05" };
    public readonly string[] bigPrefab = { "Big_01", "Big_02", "Big_03", "Big_04", "Big_05", "Big_06" };
    public readonly string[] botPrefab = { "Bot_01", "Bot_02", "Bot_03", "Bot_04", "Bot_05", "Bot_06", "Bot_07" };

    //platform controller
    public readonly string[] platformsLevelOne = { "Platform_01", "Platform_02", "Platform_03", "Platform_04", "Platform_05" };
    public readonly string[] platformsLevelTwo = { "Platform_01", "Platform_02", "Platform_03", "Platform_04", "Platform_05", "Platform_lvl2_01", "Platform_lvl2_02", "Platform_lvl2_03" };
    public readonly string[] platformsLevelThree = { "Platform_03", "Platform_05", "Platform_lvl2_01", "Platform_lvl2_02", "Platform_lvl2_03", "Platform_lvl3_01", "Platform_lvl3_02", "Platform_lvl3_03" };
    public readonly string[] platformsLevelFour = { "Platform_lvl2_01", "Platform_lvl2_03", "Platform_lvl3_01", "Platform_lvl3_02", "Platform_lvl3_03", "Platform_lvl4_01", "Platform_lvl4_02", "Platform_lvl4_03" };
    public readonly string[] platformsLevelFive = { "Platform_lvl3_01", "Platform_lvl3_02", "Platform_lvl3_03", "Platform_lvl4_01", "Platform_lvl4_02", "Platform_lvl4_03", "Platform_lvl5_01", "Platform_lvl5_02" };

    //ball base
    public readonly string destroyBallCollision = "ModularShockwaveImpact";

    //gun
    public readonly string canonShotParticle = "CannonShot";

    //bot
    public readonly string destroyBotCollision = "ModularRingImpact";

    //bot base, aim base, building base
    public readonly string destroyObjParticle = "FX_Explosion_01";

    //building base
    public readonly string destroyBuildingParticle = "DestroyObjParticle_3";
    public readonly string impactCollision = "Impact_Wood_01";

    //aim wood
    public readonly string destroyWoodParticle = "DestroyObjParticle_2";

    //aim stone
    public readonly string destroyStoneParticle = "DestroyObjParticle_1";
}