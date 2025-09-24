using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TMP_Text scoreText;
    public TMP_Text winText;
    public GameObject gate;
    public int score;

    public AudioSource audioSource;   // assign in Inspector (Player GameObject)
    public AudioClip coinSound;       // assign your coin audio clip in Inspector

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
        winText.text = "";
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            // Try to call Collect on coin component
            var coin = other.gameObject.GetComponent<Coin>();
            if (coin != null)
            {
                coin.Collect();
            }
            else
            {
                // fallback: disable immediately (no sound)
                other.gameObject.SetActive(false);
            }

            score = score + 1;
            SetScoreText();
            if (score >= 5)
            {
                gate.gameObject.SetActive(false);
            }
        }

        if (other.gameObject.CompareTag("danger"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }


    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();

        if (score >= 5)
        {
            winText.text = "You Win! Press R to restart or ESC to exit";
        }
    }
}
