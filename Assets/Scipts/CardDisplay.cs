using UnityEngine;
using UnityEngine.UI;


public class CardDisplay : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] Sprite jack;
    [SerializeField] Sprite queen;
    [SerializeField] Sprite king;
    [SerializeField] Sprite ace;
    [Header("Value Card")]
    [SerializeField] Image valueCard;
    

    Card myCard;


    // void OnValidate()
    // {
    //     SetValue(CardValue.Jack);
    // }
    public void SetCard(Card card)
    {
        myCard = card;
        SetValue(card.cardValue);
    }
    void SetValue(CardValue cardValue)
    {
        switch(cardValue)
        {
            case CardValue.Jack:
            {
                valueCard.sprite = jack;
            }
            break;
            case CardValue.Queen:
            {
                valueCard.sprite = queen;
            }
            break;
            case CardValue.King:
            {
                valueCard.sprite = king;
            }
            break;
            case CardValue.Ace:
            {
                valueCard.sprite = ace;
            }
            break;
        }
    }

}
