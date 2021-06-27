using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private bool isOverDropZone = false;
    private GameObject mainCanvas;
    private GameObject dropZone;
    private GameObject startParent;
    private Vector2 startPosition;

    // Start is called before the first frame update
    void Awake()
    {
        mainCanvas = GameObject.Find("Main Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging) {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(mainCanvas.transform, true);
        }    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isOverDropZone = true;
        dropZone = other.gameObject;
        Debug.Log(other.gameObject.name);
    }

    private void OnCollisionExit2D(Collision2D other) {
        isOverDropZone = false;
        dropZone = null;    
    }
    public void StartDrag()
    {
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        isDragging = true;
    }

    public void EndDrag()
    {
        isDragging = false;
        if (isOverDropZone) {
            transform.SetParent(dropZone.transform, false);
        } else {
            transform.SetParent(startParent.transform, false);
            transform.position = startPosition;
        }

    }
}
