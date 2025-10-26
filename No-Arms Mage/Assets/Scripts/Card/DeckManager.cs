using UnityEngine;
using System.Collections.Generic;

public class DeckManager : MonoBehaviour
{
    public Transform[] slots;
    public GameObject[] startingCards;

    private List<GameObject> currentDeckPrefabs = new List<GameObject>();
    private List<GameObject> discardPilePrefabs = new List<GameObject>();

    private void Start()
    {
        InitializeDeck();
    }

    public void InitializeDeck()
    {
        currentDeckPrefabs.Clear();
        foreach (var prefab in startingCards)
        {
            currentDeckPrefabs.Add(prefab);
        }

        GenerateDeckVisual();
    }

    private void GenerateDeckVisual()
    {
        foreach (var slot in slots)
        {
            if (slot.childCount > 0)
                Destroy(slot.GetChild(0).gameObject);
        }

        for (int i = 0; i < currentDeckPrefabs.Count; i++)
        {
            int j = Random.Range(0, currentDeckPrefabs.Count);
            var temp = currentDeckPrefabs[i];
            currentDeckPrefabs[i] = currentDeckPrefabs[j];
            currentDeckPrefabs[j] = temp;
        }

        for (int i = 0; i < currentDeckPrefabs.Count && i < slots.Length; i++)
        {
            GameObject cardGO = Instantiate(currentDeckPrefabs[i], slots[i]);
            cardGO.transform.localPosition = Vector3.zero;
        }
    }

    public void PlayCard(GameObject playedCard, GameObject cardPrefab)
    {
        if (currentDeckPrefabs.Contains(cardPrefab))
        {
            currentDeckPrefabs.Remove(cardPrefab);
            discardPilePrefabs.Add(cardPrefab);
        }

        Destroy(playedCard);

        if (currentDeckPrefabs.Count == 0 && discardPilePrefabs.Count > 0)
        {
            currentDeckPrefabs.AddRange(discardPilePrefabs);
            discardPilePrefabs.Clear();
        }

        GenerateDeckVisual();
    }

    public void AddCardToDeck(GameObject cardPrefab)
    {
        currentDeckPrefabs.Add(cardPrefab);
        GenerateDeckVisual();
    }
}
