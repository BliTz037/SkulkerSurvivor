using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField]
    private PlayerStats _playerStats;

    [SerializeField]
    private RectMask2D _rectMaskPvBar, _rectMaskShootDelayBar, _rectMaskXpBar;

    [SerializeField]
    private Text _levelText;

    [SerializeField]
    private Text _chronoText;

    private void Update()
    {

    }
}
