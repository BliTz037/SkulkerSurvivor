using UnityEngine;
using System.Collections.Generic;

public class BoostManager : MonoBehaviour
{
    [SerializeField]
    private BoostType[] _boostTypes = { BoostType.Life, BoostType.Speed, BoostType.AttackSpeed, BoostType.Damage, BoostType.SpecialAttack };

    [SerializeField]
    private PlayerStats _stats;

    public BoostType[] GenerateRandomBoosts()
    {
        BoostType[] boosts = new BoostType[2];
        List<BoostType> generatedBoosts = new();

        for (int i = 0; i < 2; i++)
        {
            BoostType randomBoost = GetRandomBoost();
            if (!generatedBoosts.Contains(randomBoost))
            {
                boosts[i] = randomBoost;
                generatedBoosts.Add(randomBoost);
            }
            else
            {
                i--;
            }
        }

        return boosts;
    }

    private BoostType GetRandomBoost()
    {
        int randomIndex = Random.Range(0, _boostTypes.Length);
        return _boostTypes[randomIndex];
    }

    public void ChooseBoost(BoostType[] boosts, int boostIndex)
    {
        if (boostIndex >= 0 && boostIndex < boosts.Length)
        {
            BoostType chosenBoost = boosts[boostIndex];
            ApplyBoost(chosenBoost);
        }
        else
        {
            Debug.LogError("Invalid boost index: " + boostIndex);
        }
    }

    public void ApplyBoost(BoostType boost)
    {
        switch (boost)
        {
            case BoostType.Life:
                _stats.Hp += 1;
                break;
            case BoostType.Speed:
                _stats.Speed *= 1.1f;
                break;
            case BoostType.AttackSpeed:
                _stats.FireRate *= 0.9f;
                break;
            case BoostType.Damage:
                _stats.Damage += 1;
                break;
            case BoostType.SpecialAttack:
                if (_stats.SpecialAttack == 0)
                    _stats.SpecialAttack = 2;
                else
                    _stats.SpecialAttack += 1;
                break;
            default:
                Debug.LogError("Invalid boost type: " + boost);
                break;
        }
    }
}
