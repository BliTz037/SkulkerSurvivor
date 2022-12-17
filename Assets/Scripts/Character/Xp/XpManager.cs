using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpManager : MonoBehaviour
{
    public int CurrentLevel = 1;

    public int CurrentXp = 0;

    public int XpToNextLevel = 100;

    [SerializeField]
    private PanelCard _panelCard;

    public void AddXp(int xp)
    {
        CurrentXp += xp;
        if (CurrentXp >= XpToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        CurrentLevel++;
        CurrentXp = 0;
        XpToNextLevel = (int)(XpToNextLevel * 1.25f);
        _panelCard.DisplayBonusCardSelect();
    }

    public void Reset()
    {
        CurrentLevel = 1;
        CurrentXp = 0;
        XpToNextLevel = 100;
    }
}
