using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CardInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    CardDisplay cardDisplay;
    Vector3 originalPosition;
    float liftAmount = 30f; 
    void Start()
    {
        cardDisplay = GetComponent<CardDisplay>();
        originalPosition = transform.localPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        LiftCard(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LiftCard(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(cardDisplay.Owner.IsHuman)
        {
            Debug.Log("clicked a :" + cardDisplay.MyCard.cardValue.ToString());
        }
    }

    void LiftCard(bool lift)
    {
        if(lift && cardDisplay.Owner.IsHuman)
        {
            transform.localPosition = originalPosition + new Vector3(0,liftAmount,0);
        }
        else
        {
            transform.localPosition = originalPosition;
        }
    }
}
