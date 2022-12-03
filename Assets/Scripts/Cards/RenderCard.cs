using System;
using UnityEngine;
using UnityEngine.UI;

public class RenderCard : MonoBehaviour
{
    public Text NameText;
    public Text DescriptionText;
    public Image ImageCard;
    public Image BackgroundDescriptionColor;
    
    private Card _card;

    // Start is called before the first frame update
    void Awake()
    {
        _card = GetComponent<Card>();
        Render();
    }

    private void Render()
    {
        NameText.text = Enum.GetName(typeof(BoostType), _card.Type);
        DescriptionText.text = _card.Description;
        ImageCard.sprite = _card.Image;
        BackgroundDescriptionColor.color = Color.black;
    }
}
