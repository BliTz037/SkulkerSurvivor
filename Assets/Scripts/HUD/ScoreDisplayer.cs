using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField]
    private PlayerStats _playerStats;

    [SerializeField]
    private XpManager _xpManager;

    [SerializeField]
    private Stopwatch _stopwatch;

    [SerializeField]
    private RectMask2D _rectMaskPvBar, _rectMaskXpBar;

    [SerializeField]
    private Text _levelText;

    [SerializeField]
    private Text _chronoText;

    private void Update()
    {
        _rectMaskPvBar = SetBar(_rectMaskPvBar, _playerStats.Hp, _playerStats.MaxHp);
        _rectMaskXpBar = SetBar(_rectMaskXpBar, _xpManager.CurrentXp, _xpManager.XpToNextLevel);

        TimeSpan time = TimeSpan.FromSeconds(_stopwatch.CurrentTime);
        _chronoText.text = time.ToString(@"mm\:ss");
        _levelText.text = _xpManager.CurrentLevel + " Lvl";
    }

    private RectMask2D SetBar(RectMask2D mask, float value, float maxValue)
    {
        Vector4 newMask = mask.padding;
        newMask.z = 410 - ((410 / maxValue) * value);
        mask.padding = newMask;
        return mask;
    }
}
