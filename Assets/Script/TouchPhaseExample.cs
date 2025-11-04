using TMPro;
using UnityEngine;

public class TouchPhaseExample : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;
    public TextMeshProUGUI textMeshProUGUI;
    public string message;

    void Update()
    {
        textMeshProUGUI.text = "Touch: " + message + " Direction: " + direction + " Position: " + startPos;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    message = "Began";
                break;
                case TouchPhase.Moved:
                    message = "Moving";
                    direction = touch.position - startPos;
                break;
                case TouchPhase.Ended:
                    message = "Ending";
                break;
                case TouchPhase.Stationary:
                    message = "Stationary";
                    Debug.Log("Stationary is: " + touch.position);
                break;
                case TouchPhase.Canceled:
                    message = "Canceled";
                break;
            }
       }
    }

}
