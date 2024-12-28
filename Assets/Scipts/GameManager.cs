using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Player> players = new List<Player>();
    [SerializeField] Deck deck;
    [SerializeField] Transform playerHandTransform;
    [SerializeField] List<Transform> aiHandTransforms = new List<Transform>();
    [SerializeField] GameObject cardPrefab;
    [SerializeField] int numberOfAiPlayers = 3;
    [SerializeField] int startingHandSize = 5;
    int currentPlayer = 0;
    void Awake() 
    {
        instance = this;
    }

    void Start()
    {
        deck.InitializeDeck();
        InitializePlayers();
        StartCoroutine(DealStartingCards());
    }

    void InitializePlayers()
    {
        players.Clear();    
        players.Add(new Player("Player",true));
        for (int i = 0; i< numberOfAiPlayers;i++)
        {
            players.Add(new AIPlayer("AI" + (i+1)));
        }
    }

    void DealCards()
    {
        for (int i =0; i < startingHandSize; i++)
        {
            foreach (Player player in players)
            {
                player.DrawCard(deck.DrawCard());
            }
        }
    }

    IEnumerator DealStartingCards()
    {
        for (int i = 0; i < startingHandSize; i++)
        {
            foreach (Player player in players)
            {
                Card drawnCard = deck.DrawCard();
                player.DrawCard(drawnCard);
                Transform hand = player.IsHuman ? playerHandTransform : aiHandTransforms[players.IndexOf(player)-1];
                GameObject card = Instantiate(cardPrefab,hand,false);
                card.GetComponent<CardDisplay>().SetCard(drawnCard);

                if(!player.IsHuman)
                {

                }

                yield return new WaitForSeconds(0.1f);
            }
        }
        Debug.Log("The game  is allowed to start");
    }
}
