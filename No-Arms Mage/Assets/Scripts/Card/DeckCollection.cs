using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCollection : MonoBehaviour
{
    public List<GameObject> deck = new List<GameObject>();

    public void AddCard(GameObject cardPrefab)
    {
        deck.Add(cardPrefab);
        Debug.Log("Carta adicionada ao deck: " + cardPrefab.name);
    }
}
