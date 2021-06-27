using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    private GameObject mainCanvas;
    private GameObject zoomedCard;
    void Awake()
    {
        mainCanvas = GameObject.Find("Main Canvas");
    }

    public void onHoverEnter()
    {
        zoomedCard = Instantiate(gameObject, new Vector2(Input.mousePosition.x, Input.mousePosition.y + 250), Quaternion.identity);
        zoomedCard.transform.SetParent(mainCanvas.transform, true);
        zoomedCard.layer = LayerMask.NameToLayer("Zoom");

        RectTransform rect = zoomedCard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(240, 340);
    }

    public void onHoverExit()
    {
        Destroy(zoomedCard);
    }
}
