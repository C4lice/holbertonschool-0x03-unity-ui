using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;

    public int health = 5;

    public Text scoreText;

    public Text healthText;

    public GameObject winLoseBG;
    public Text winLoseText;

    private Rigidbody rb;

    private int score = 0;

    private bool gameEnded = false;
    // Initialisation
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        SetScoreText();
        SetHealthText();
    }
    // Gérer le mouvement du joueur
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        // Position et déplacement du joueur
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

    }

    void Update()
    {
        // Vérifier la santé du joueur
        if (health <= 0 && !gameEnded)
        {
            gameEnded = true;

            winLoseBG.SetActive(true);
            winLoseText.text = "Game Over!";
            winLoseText.color = Color.white;
            winLoseBG.GetComponent<Image>().color = Color.red;

            StartCoroutine(LoadScene(3));
        }
    }
    // Gérer les collisions avec les pickups, les traps et les goals
    void OnTriggerEnter(Collider other)
    {
        // Pickup
        if (other.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            other.gameObject.SetActive(false);
        }
        // Trap
        if (other.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
        }
        // Goal
        if (other.CompareTag("Goal") && !gameEnded)
        {
            gameEnded = true;

            winLoseBG.SetActive(true);
            winLoseText.text = "You Win!";
            winLoseText.color = Color.black;
            winLoseBG.GetComponent<Image>().color = Color.green;

            StartCoroutine(LoadScene(3));
        }
    }
    // Recharger la scène après un délai
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Mettre à jour le texte du score et de la santé
    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }
}
