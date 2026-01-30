using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Vitesse du joueur
    public float speed = 5f;
    // Points de vie du joueur
    public int health = 5;

    // Référence au Rigidbody
    private Rigidbody rb;
    // Score du joueur
    private int score = 0;

    void Start()
    {
        // On récupère le Rigidbody attaché au Player
        rb = GetComponent<Rigidbody>();
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
            Debug.Log("Game Over!");

            // Réinitialiser les valeurs
            health = 5;
            score = 0;

            // Recharger la scène actuelle
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    // Gestion des collisions avec les triggers
    void OnTriggerEnter(Collider other)
    {
        // Gestion des pickups
        if (other.CompareTag("Pickup"))
        {
            score++;
            Debug.Log("Score: " + score);
            other.gameObject.SetActive(false);
        }
        // Gestion des pièges
        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health);
        }
        // Gestion de l’arrivée au but
        if (other.CompareTag("Goal"))
        {
        Debug.Log("You win!");
        }
    }
}
