using UnityEngine;
using UnityEngine.EventSystems;

public class CardSelector : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject cardSelectManager = GameObject.Find("CardSelectManager");

        cardSelectManager.GetComponent<PanelCard>().SelectCard(transform.GetChild(0).gameObject);
    }
}
