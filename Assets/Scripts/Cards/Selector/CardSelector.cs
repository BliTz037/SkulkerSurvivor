using UnityEngine;
using UnityEngine.EventSystems;

public class CardSelector : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject parent = transform.parent.gameObject;

        parent.GetComponent<PanelCard>().SelectCard(transform.GetChild(0).gameObject);
    }
}
