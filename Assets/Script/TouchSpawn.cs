using UnityEngine;

public class TouchSpawn : MonoBehaviour
{
    public GameObject[] gameObjects;
    private int index = 0;
    private AudioSource audioSource;
    public AudioClip audioClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector2 position = Camera.main.ScreenToWorldPoint(touch.position);

                Collider2D hit = Physics2D.OverlapPoint(position);

                if (hit != null)
                {
                    if (audioClip != null)
                    {
                        audioSource.PlayOneShot(audioClip);
                    }
                    Destroy(hit.gameObject);
                }
                Instantiate(gameObjects[index], position, Quaternion.identity);

                index = (index+1) % gameObjects.Length;
            }
        }
    }
}
