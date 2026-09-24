using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float velocidad = 10f;

    // Ya no necesitamos el Start con el Destroy por tiempo, usaremos la salida de pantalla

    void Update()
    {
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);
    }

    // Esta función especial de Unity se ejecuta JUSTO cuando la bala sale de la pantalla
    void OnBecameInvisible()
    {
        // Buscamos al árbitro del juego
        GameManager gm = FindObjectOfType<GameManager>();
        
        // Si el árbitro existe, le pedimos que sume un número negativo (restar)
        if (gm != null)
        {
            gm.SumarPuntos(-2); // Aquí puedes poner el castigo que quieras, por ejemplo -5
        }

        // Finalmente, la bala se destruye a sí misma para no saturar la memoria
        Destroy(gameObject);
    }
}