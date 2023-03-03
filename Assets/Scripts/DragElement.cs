using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragElement : MonoBehaviour
{
    public Rigidbody2D selectedObject;

    Rigidbody2D rigidbody2d;
    PointerEventData eventData;
    Vector2 offset;
    Vector2 mousePosition;
    Collider2D targetObject;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject && targetObject.gameObject == rigidbody2d.gameObject) 
            {
                selectedObject = rigidbody2d;
                offset = selectedObject.position - mousePosition;
            }

        }
        else if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
        }
    }

    void FixedUpdate() 
    {
        if (selectedObject)
        {
            selectedObject.MovePosition(mousePosition + offset);
        }
    }

}
