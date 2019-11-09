using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick: MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    Image joystickBG;
    [SerializeField]
    Image joystick;
    Vector2 inputVector;

    void Start()
    {
        inputVector = Vector2.zero;
        joystickBG = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }
    
    public void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        RectTransform joyRect = joystickBG.rectTransform;
        joyRect. sizeDelta.Scale(new Vector2(0.5f, 0.5f));
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joyRect, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / joyRect.sizeDelta.x);
            pos.y = (pos.y / joyRect.sizeDelta.y);

            inputVector = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            joystick.rectTransform.anchoredPosition = 
                new Vector2(inputVector.x * (joyRect.sizeDelta.x / 2),
                    inputVector.y * (joyRect.sizeDelta.y / 2));

        }
    }

    public float Horizontal()
    {
        return inputVector.x;
    }

    public float Vertical()
    {
        return inputVector.y;
    }
}