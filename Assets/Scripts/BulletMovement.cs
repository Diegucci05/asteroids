using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float velocidad = 10f;


    void Update()
    {
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        
        if (gm != null)
        {
            gm.SumarPuntos(-2);
        }

        Destroy(gameObject);
    }
}