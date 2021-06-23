using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject card1Prefab;
    public GameObject card2Prefab;
    public GameObject playerArea;
    public GameObject enemyArea;

    List<GameObject> cards = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        cards.Add(card1Prefab);
        cards.Add(card2Prefab);
    }

    public void onClick() {
        for (int i = 0; i < 5; ++i) {
            GameObject playerCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(playerArea.transform, false);
            GameObject enemyCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            enemyCard.transform.SetParent(enemyArea.transform, false);
        }
    }
}
