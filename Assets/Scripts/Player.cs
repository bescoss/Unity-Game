using UnityEngine;
using TMPro;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxSpeed = 100f;
    public Animator playerrun;
    public TMP_Text speedText;
    public float speed = 20f;
    public float left_limit = -5;
    public float right_limit = 5;
    bool gameover = false;
    public GameOverScreen gameOverScreen;

    private void Update()
    {
        if (!gameover)
        {
            UpdatePlayerPosition();
            UpdateSpeed();
        }
    }

    void UpdateSpeed()
    {
        if (speed < maxSpeed)
        {
            speed += 1.9f * Time.deltaTime;
        }

        speedText.text = Mathf.FloorToInt(speed).ToString() + " Km/h";
    }

    void UpdatePlayerPosition()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Only move the player when the touch is active
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                // Get the touch position and update the player's position
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10)); // Adjust the z-coordinate as per your camera setup
                if (touchPosition.x < right_limit && touchPosition.x > left_limit)
                {
                    transform.position = new Vector3(touchPosition.x, transform.position.y, transform.position.z);
                }
            }
        }
    transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        playerrun.speed = 0f;
        gameover = true;
        gameOverScreen.Setup(((int)speed));
        Debug.Log("Collided");


        if (collision.gameObject.CompareTag("Obstacle"))
        {
        }
        else if (collision.gameObject.CompareTag("Collectible"))
        {
            // Handle collision with collectibles
            Debug.Log("Collided with a collectible!");

            // You can add more logic here such as increasing player's score, removing the collectible, etc.
        }
    }

}
