using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Configuración")]
    public float velocidad = 5f;
    public GameObject prefabBala;
    public Transform puntoDisparo;

    private Camera camaraPrincipal;

    private float limitePantallaX; 
    private float limitePantallaY;

    void Start()
    {
        camaraPrincipal = Camera.main;
        Vector3 limites = camaraPrincipal.ViewportToWorldPoint(new Vector3(1, 1, camaraPrincipal.nearClipPlane));
    
        limitePantallaX = limites.x;
        limitePantallaY = limites.y;
    }

    void Update()
    {
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoY = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(movimientoX, movimientoY, 0) * velocidad * Time.deltaTime, Space.World);

        RotarHaciaRaton();

        if (Input.GetMouseButtonDown(0))
        {
            Disparar();
        }
    }

    void ControlarBordesPantalla()
{
    Vector3 posicion = transform.position;

    if (posicion.x > limitePantallaX) posicion.x = -limitePantallaX;
    else if (posicion.x < -limitePantallaX) posicion.x = limitePantallaX;

    if (posicion.y > limitePantallaY) posicion.y = -limitePantallaY;
    else if (posicion.y < -limitePantallaY) posicion.y = limitePantallaY;

    transform.position = posicion;
}

    void RotarHaciaRaton()
    {
        Vector3 posicionRaton = camaraPrincipal.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diferencia = posicionRaton - transform.position;
        diferencia.Normalize();

        float angulo = Mathf.Atan2(diferencia.y, diferencia.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0f, 0f, angulo);
    }

    void Disparar()
    {
        Instantiate(prefabBala, puntoDisparo.position, puntoDisparo.rotation);
    }

    private void OnTriggerEnter2D(Collider2D otroObjeto)
    {
        if (otroObjeto.CompareTag("Enemigo"))
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log("¡El jugador ha muerto!");
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}