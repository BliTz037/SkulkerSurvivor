using UnityEngine;

[System.Serializable]
public class Card : MonoBehaviour
{
    public string CardName = "Unknown";
    public string Description = "Unknown description";
    public BoostType Type = BoostType.Life;
    public Sprite Image;
}
