using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float velocidad = 3f;

    void Start()
    {
        Destroy(gameObject, 6f);
    }

    void Update()
    {
        transform.Translate(Vector3.down * velocidad * Time.deltaTime);
    }

    // Esta función la llama Unity automáticamente al chocar
    private void OnTriggerEnter2D(Collider2D otroObjeto)
{
    if (otroObjeto.CompareTag("Bala"))
    {
        // Busca al GameManager en la escena y le dice que sume 10 puntos
        FindObjectOfType<GameManager>().SumarPuntos(10);

        Destroy(otroObjeto.gameObject);
        Destroy(gameObject);
    }
}
}