using System;
using System.Collections.Generic;
using UnityEngine;

public class PanelCard : MonoBehaviour
{
    public GameObject CardSelect;
    public Transform PanelTransform;
    public GameObject CardSelectorPrefab;
    public List<GameObject> _cardsPrefab = new();

    public float TimeDelayAnimation = 0.8F;
    public BoostManager BoostManager;

    private BoostType[] _boostsType;
    private BoostType _boostTypeSelected;
    private List<GameObject> _instantiateCards = new();


    public void SelectCard(GameObject card)
    {
        _boostTypeSelected = card.GetComponent<Card>().Type;
        BoostManager.ApplyBoost(_boostTypeSelected);
        ClearCards();
        CardSelect.SetActive(false);
        ChangeGameState(false);
    }

    private void ClearCards()
    {
        foreach(GameObject card in _instantiateCards)
        {
            Destroy(card);
        }
        _instantiateCards.Clear();
    }

    public void DisplayBonusCardSelect()
    {
        List<GameObject> cards = new();

        CardSelect.SetActive(true);
        _boostsType = BoostManager.GenerateRandomBoosts();
        for (int i = 0; i < 2; i++)
        {
            var tmp = _cardsPrefab.Find(o => o.GetComponent<Card>().Type == _boostsType[i]);
            cards.Add(tmp);
        }
        for (int i = 0; i < cards.Count; i++)
        {
            GameObject newCard = Instantiate(CardSelectorPrefab, PanelTransform);
            Instantiate(cards[i], newCard.transform);
            _instantiateCards.Add(newCard);
        }
        ChangeGameState(true);
    }

    private void ChangeGameState(bool isDisplaying)
    {
        if (isDisplaying)
        {
            StateManager.Instance().CurrentState = State.LevelUp;
        }
        else
        {
            StateManager.Instance().CurrentState = State.Game;
        }
    }
}
