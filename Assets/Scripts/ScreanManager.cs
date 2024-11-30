using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreanManager : MonoBehaviour
{
    public Button myButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector2 touchPosition = touch.position;
                if (IsTouchOverButton(touchPosition))
                {
                    myButton.onClick.Invoke();
                }
            }
        }
    }

    bool IsTouchOverButton(Vector2 touchPosition)
    {
        RectTransform rectTransform = myButton.GetComponent<RectTransform>();
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, touchPosition, null, out localPoint);
        return rectTransform.rect.Contains(localPoint);
    }

}
