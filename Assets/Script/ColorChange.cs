using UnityEngine;
using UnityEngine.UIElements;

public class ColorChange : MonoBehaviour
{
    public Color[] colorDoor;
    private SpriteRenderer sprite;
    private int index = 0;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();


        // colorDoor[0] = Color.red;
        // colorDoor[1] = Color.green;
        // colorDoor[2] = Color.blue;

        colorDoor = new Color[3];
        for (int i = 0; i < colorDoor.Length; i++)
        {
            colorDoor[i] = Random.ColorHSV();
        }

        sprite.color = colorDoor[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColor();
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ChangeColor();
        }
    }

    private void ChangeColor()
    {
        index++;
        if (index >= colorDoor.Length)
        {
            index = 0;
        }
        sprite.color = colorDoor[index];
    }
}
