using UI.Loader;
using UnityEngine;

public static class GameController
{
    public static float GlobalLevelTimer = 0;
    public static float GlobalLevelPointer = 0;
    
    
    public const int RoboEnemyPoint = 5;
    public const int ZombieEnemyPoint = 3;
    public const int GirlZombieEnemyPoint = 3;
    public const int RoboBossPoint = 25;
    public const int DuckBossPoint = 20;

    public static bool GameStatus = false;
    public const bool DebugMode = true;

    public const string AdmobTestInterstitial = "ca-app-pub-3940256099942544/1033173712";
    public const string AdmobTestRewarded = "ca-app-pub-3940256099942544/5224354917";

    public const int AttackDamageCost = 100;
    public const int AttackSpeedCost = 80;
    public const int DefencePowerCost = 120;
    public const int SpeedCost = 50;
    public const int EnemyReducerCost = 175;

    public const float MaxAttackDamageBuff = 15F;
    public const float MaxAttackSpeedBuff = 0.5F;
    public const float MaxDefencePowerBuff = 15F;
    public const float MaxSpeedPowerBuff = 12.5F;
    public const float MaxEnemyReducerBuff = 7.5F;

    public static void AddCoin(int amount)
    {
        var coin = PlayerPrefs.GetInt("Coin");
        PlayerPrefs.SetInt("Coin", coin + amount);
    }

    public static void RemoveCoin(int amount)
    {
        var coin = PlayerPrefs.GetInt("Coin");
        PlayerPrefs.SetInt("Coin", coin - amount);
    }

    public static void ReturnToMainMenu()
    {
        SceneLoader.Load(Scenes.Menu);
    }

    public static int GetCoin()
    {
        var coin = PlayerPrefs.GetInt("Coin");
        return coin;
    }

    //ATTACK DAMAGE
    public static void AddUserAttackDamageBuff()
    {
        var attackDamage = PlayerPrefs.GetFloat("AttackDamagePower");
        attackDamage += MaxAttackDamageBuff / 5F;
        if (attackDamage > MaxAttackDamageBuff)
        {
            attackDamage = MaxAttackDamageBuff;
        }

        PlayerPrefs.SetFloat("AttackDamagePower", attackDamage);
    }


    public static float GetUserAttackDamageBuff()
    {
        var attackDamage = PlayerPrefs.GetFloat("AttackDamagePower");
        return attackDamage;
    }

    public static int GetAttackDamageCost()
    {
        var maxCost = AttackDamageCost;

        var current = GetUserAttackDamageBuff();
        var maxPower = MaxAttackDamageBuff;
        var multiplier = (current / maxPower) + 0.2F;

        return (int) (maxCost * multiplier);
    }

    //ATTACK SPEED
    public static void AddUserAttackSpeedPowerBuff()
    {
        var attackSpeed = PlayerPrefs.GetFloat("AttackSpeed");
        attackSpeed += MaxAttackSpeedBuff / 5F;
        if (attackSpeed > MaxAttackSpeedBuff)
        {
            attackSpeed = MaxAttackSpeedBuff;
        }

        PlayerPrefs.SetFloat("AttackSpeed", attackSpeed);
    }

    public static float GetUserAttackSpeedBuff()
    {
        var attackSpeed = PlayerPrefs.GetFloat("AttackSpeed");
        return attackSpeed;
    }

    public static int GetAttackSpeedCost()
    {
        var maxCost = AttackSpeedCost;

        var current = GetUserAttackSpeedBuff();
        var maxPower = MaxAttackSpeedBuff;
        var multiplier = (current / maxPower) + 0.2F;

        return (int) (maxCost * multiplier);
    }

    //DEFENCE POWER
    public static void AddUserDefencePowerBuff()
    {
        var defencePower = PlayerPrefs.GetFloat("DefencePower");
        defencePower += MaxDefencePowerBuff / 5F;
        if (defencePower > MaxDefencePowerBuff)
        {
            defencePower = MaxDefencePowerBuff;
        }

        PlayerPrefs.SetFloat("DefencePower", defencePower);
    }

    public static float GetUserDefencePowerBuff()
    {
        var defencePower = PlayerPrefs.GetFloat("DefencePower");
        return defencePower;
    }

    public static int GetDefencePowerCost()
    {
        var maxCost = DefencePowerCost;

        var current = GetUserDefencePowerBuff();
        var maxPower = MaxDefencePowerBuff;
        var multiplier = (current / maxPower) + 0.2F;

        return (int) (maxCost * multiplier);
    }

    //SPEED POWER
    public static void AddUserSpeedPowerBuff()
    {
        var speedPower = PlayerPrefs.GetFloat("SpeedPower");
        speedPower += MaxSpeedPowerBuff / 5F;
        if (speedPower > MaxSpeedPowerBuff)
        {
            speedPower = MaxSpeedPowerBuff;
        }

        PlayerPrefs.SetFloat("SpeedPower", speedPower);
    }

    public static float GetUserSpeedPowerBuff()
    {
        var speedPower = PlayerPrefs.GetFloat("SpeedPower");
        return speedPower;
    }

    public static int GetSpeedPowerCost()
    {
        var maxCost = SpeedCost;

        var current = GetUserSpeedPowerBuff();
        var maxPower = MaxSpeedPowerBuff;
        var multiplier = (current / maxPower) + 0.2F;

        return (int) (maxCost * multiplier);
    }

    //ENEMY REDUCER
    public static void AddEnemyReducerBuff()
    {
        var enemyReducer = PlayerPrefs.GetFloat("EnemyReducer");
        enemyReducer += MaxEnemyReducerBuff / 5F;
        if (enemyReducer > MaxEnemyReducerBuff)
        {
            enemyReducer = MaxEnemyReducerBuff;
        }

        PlayerPrefs.SetFloat("EnemyReducer", enemyReducer);
    }

    public static float GetEnemyReducerBuff()
    {
        var enemyReducer = PlayerPrefs.GetFloat("EnemyReducer");
        return enemyReducer;
    }

    public static int GetEnemyReducerCost()
    {
        var maxCost = EnemyReducerCost;

        var current = GetEnemyReducerBuff();
        var maxPower = MaxEnemyReducerBuff;
        var multiplier = (current / maxPower) + 0.2F;

        return (int) (maxCost * multiplier);
    }
}