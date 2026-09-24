using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabEnemigo;
    public float tiempoEntreSpawns = 2f; // Aparece uno cada 2 segundos
    
    private float temporizador = 0f;

    void Update()
    {
        // Sumamos el tiempo que pasa en cada fotograma al temporizador
        temporizador += Time.deltaTime;

        // Si el temporizador supera nuestro límite de 2 segundos...
        if (temporizador >= tiempoEntreSpawns)
        {
            Spawn();
            temporizador = 0f; // Reiniciamos el reloj a cero
        }
    }

    void Spawn()
    {
        // Calculamos un número aleatorio para el eje X (de izquierda a derecha). 
        // NOTA: Si tu cámara es más ancha, puedes cambiar el -8f y 8f por otros números.
        float posicionXAleatoria = Random.Range(-8f, 8f);
        
        // Creamos la coordenada final: la X aleatoria, la Y del Spawner, y Z a cero.
        Vector3 posicionAparicion = new Vector3(posicionXAleatoria, transform.position.y, 0);

        // Quaternion.identity significa "sin rotación extra"
        Instantiate(prefabEnemigo, posicionAparicion, Quaternion.identity);
    }
}