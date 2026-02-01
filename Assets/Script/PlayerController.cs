using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Vitesse du joueur
    public float speed = 5f;
    // Points de vie du joueur
    public int health = 5;
    // Référence au Text pour afficher le score
    public Text scoreText;
    // Référence au Text pour afficher la santé
    public Text healthText;
    // Références pour l’affichage de la victoire/défaite
    public GameObject winLoseBG;
    public Text winLoseText;
    // Référence au Rigidbody
    private Rigidbody rb;
    // Score du joueur
    private int score = 0;

    void Start()
    {
        // On récupère le Rigidbody attaché au Player
        rb = GetComponent<Rigidbody>();
        // Initialisation de l’affichage du score et de la santé
            SetScoreText();
            SetHealthText();
    }
    // Gestion du mouvement du joueur
    void FixedUpdate()
    {
        // Récupération des entrées clavier (WASD / flèches)
        float moveX = Input.GetAxis("Horizontal"); // A/D ou ← →
        float moveZ = Input.GetAxis("Vertical");   // W/S ou ↑ ↓

        // Création du vecteur de mouvement (pas de Y → pas de saut)
        Vector3 movement = new Vector3(moveX, 0f, moveZ);

        // Déplacement du joueur via la physique
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    // Vérification de la santé du joueur
    void Update()
    {
        if (health <= 0)
        {
            winLoseBG.SetActive(true);

            winLoseText.text = "Game Over!";
            winLoseText.color = Color.white;

            Image bgImage = winLoseBG.GetComponent<Image>();
            bgImage.color = Color.red;
        }
    }

    // Gestion des collisions avec les triggers
    void OnTriggerEnter(Collider other)
    {
        // Gestion des pickups
        if (other.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            other.gameObject.SetActive(false);
        }
        // Gestion des pièges
        if (other.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
        }
        // Gestion de l’arrivée au but
        if (other.CompareTag("Goal"))
        {
            winLoseBG.SetActive(true);

            winLoseText.text = "You Win!";
            winLoseText.color = Color.black;

            Image bgImage = winLoseBG.GetComponent<Image>();
            bgImage.color = Color.green;
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }
}
