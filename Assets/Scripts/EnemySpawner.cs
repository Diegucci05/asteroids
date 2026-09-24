using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabEnemigo;
    public float tiempoEntreSpawns = 1f;
    
    private float temporizador = 0f;

    void Update()
    {
        temporizador += Time.deltaTime;

        if (temporizador >= tiempoEntreSpawns)
        {
            Spawn();
            temporizador = 0f;
        }
    }

    void Spawn()
    {
        float posicionXAleatoria = Random.Range(-8f, 8f);
        
        Vector3 posicionAparicion = new Vector3(posicionXAleatoria, transform.position.y, 0);

        Instantiate(prefabEnemigo, posicionAparicion, Quaternion.identity);
    }
}