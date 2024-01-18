using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    bool alive = true;
    float baseSpeed = 5;
    [SerializeField]
    TMP_Text distanceText;  

    [SerializeField]
    // Initial speed
    float currentSpeed;   // Current speed
    float totalDistance = 0f; // Variable to store the total distance traveled

    public float speedIncreaseRate = 1.1f;  // Speed increase rate per second

    [SerializeField] Rigidbody rb;
    [SerializeField] float horizontalMultiplier = 2;
    float horizontalInput;

    private void FixedUpdate()
    {
        if (!alive) return;

        // Gradually increase the speed over time
        currentSpeed += speedIncreaseRate * Time.fixedDeltaTime;

        Vector3 forwardMove = transform.forward * currentSpeed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * currentSpeed * Time.fixedDeltaTime * horizontalInput * horizontalMultiplier;

        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        totalDistance += forwardMove.magnitude;
        if (distanceText != null)
        {
            distanceText.text = "Score: " + totalDistance.ToString("F2");
        }

    }

    void Start()
    {
        anim=GetComponent<Animator>();
        currentSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.y < -5)
        {
            Die();
        }
    }

    [SerializeField] GameObject DieScene;
    [SerializeField] TextMeshProUGUI dieScoreText;
    [SerializeField] GameObject displayScore;
    [SerializeField] AudioManager audioManager;
    

    public void Die()
    {
        audioManager.PlayAudioSound(0); // Hit sound

        if (totalDistance > PlayerPrefs.GetFloat("score", 0f))
        {
            PlayerPrefs.SetFloat("score", totalDistance);
        }

        alive = false;
        anim.SetBool("IsCollided", true);

        dieScoreText.text = "Score: " + totalDistance.ToString("F2");
        displayScore.SetActive(false);

        Invoke(nameof(ShowRestartScene), 1);

        //Invoke("Restart", 2);

    }

    void ShowRestartScene()
    {
        DieScene.SetActive(true);

    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
