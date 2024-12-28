using UnityEngine;
using UnityEngine.UI;


public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Image cardImage;

    public void Start()
    {
        if (card != null && cardImage != null)
        {
            cardImage.sprite = card.cardSprite;
        }
    }

}
