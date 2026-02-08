using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

// Contrôleur de joueur pour gérer les mouvements, les collisions et l'état du jeu.
public class PlayerController : MonoBehaviour
{
    private int score = 0;

    public Text scoreText;

    public Text healthText;

    public Text WinOrLoose;

    public Image WinLoseBG;

    public int health = 5;

    [Tooltip("speed of the player")]
    [SerializeField]
    public float speed;

    private Rigidbody rb;
    // Start est appelé avant la première mise à jour d'image.
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // La mise à jour est appelée une fois par image.
    public void Update()
    {
        // Si la santé du joueur atteint 0, affiche un message de défaite et recharge la scène après 3 secondes.
        if (health == 0)
        {
            WinLoseBG.color = Color.red;
            WinOrLoose.color = Color.white;
            WinOrLoose.text = "Game Over!";
            WinLoseBG.gameObject.SetActive(true);
            //Debug.Log("Game Over!");
            StartCoroutine(LoadScene(3));
        }
        // Charger la scène du menu principal lorsque la touche Échap est enfoncée.
        if (Input.GetKeyDown(KeyCode.Escape)) {
            OnButtonClicked();
        }
    }
    // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    public void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Si le joueur entre en collision avec un objet de collecte, augmente son score de 1, met à jour le texte du score et détruit l'objet de collecte.
        if (other.CompareTag("Pickup")) 
        {
            score += 1;
            //Debug.Log($"Score: {score}");
            SetScoreText();
            Destroy(other.gameObject);
        }
        // Si le joueur entre en collision avec un piège, réduit sa santé de 1 et met à jour le texte de la santé.
        else if (other.CompareTag("Trap"))
        {
            health -= 1;
            SetHealthText();
            //Debug.Log($"Health: {health}");
        }
        // Si le joueur atteint l'objectif, affiche un message de victoire et recharge la scène après 3 secondes.
        else if (other.CompareTag("Goal"))
        {
            WinLoseBG.color = Color.green;
            WinOrLoose.color = Color.black;
            WinOrLoose.text = "You Win!";
            WinLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
            //Debug.Log("You win!");
        }
    }
    // Met à jour le texte du score du joueur.
    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }
    // Met à jour le texte de la santé du joueur.
    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }
    // Coroutine pour charger la scène après un délai de 3 secondes.
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Charger la scène du menu principal lorsque la touche Échap est enfoncée.
    void OnButtonClicked()
    {
        SceneManager.LoadScene (sceneName:"menu");
    }
}
