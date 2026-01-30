using UnityEngine;


public class Rotator : MonoBehaviour
{
    void Update()
    {
        // Rotation continue sur l’axe X
        transform.Rotate(45f * Time.deltaTime, 0f, 0f);
    }
}
