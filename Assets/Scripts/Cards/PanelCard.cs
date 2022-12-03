using System;
using System.Collections.Generic;
using UnityEngine;


public class PanelCard : MonoBehaviour
{
    public GameObject CardSelectorPrefab;
    public List<GameObject> _cardsPrefab = new();

    public float TimeDelayAnimation = 0.8F;
    public BoostManager BoostManager;

    private BoostType[] _boostsType;
    private BoostType _boostTypeSelected;
    private List<GameObject> _instantiateCards = new();

    // Start is called before the first frame update
    void Start()
    {
        InstantiateCard();
    }

    public void SelectCard(GameObject card)
    {
        _boostTypeSelected = card.GetComponent<Card>().Type;
        BoostManager.ApplyBoost(_boostTypeSelected);
        ClearCards();
    }

    void ClearCards()
    {
        foreach(GameObject card in _instantiateCards)
        {
            Destroy(card);
        }
        _instantiateCards.Clear();
    }

    void InstantiateCard()
    {
        List<GameObject> cards = new();

        _boostsType = BoostManager.GenerateRandomBoosts();
        for (int i = 0; i < 2; i++)
        {
            var tmp = _cardsPrefab.Find(o => o.GetComponent<Card>().Type == _boostsType[i]);
            cards.Add(tmp);
        }
        for (int i = 0; i < cards.Count; i++)
        {
            GameObject newCard = Instantiate(CardSelectorPrefab, transform);
            Instantiate(cards[i], newCard.transform);
            _instantiateCards.Add(newCard);
        }
    }
}
