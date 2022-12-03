using UnityEngine;
using System.Collections.Generic;

public class BoostManager : MonoBehaviour
{
    [SerializeField]
    private BoostType[] _boostTypes = { BoostType.Life, BoostType.Speed, BoostType.AttackSpeed, BoostType.Damage, BoostType.SpecialAttack };

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
                break;
            case BoostType.Speed:
                break;
            case BoostType.AttackSpeed:
                break;
            case BoostType.Damage:
                break;
            case BoostType.SpecialAttack:
                break;
            default:
                Debug.LogError("Invalid boost type: " + boost);
                break;
        }
    }
}
