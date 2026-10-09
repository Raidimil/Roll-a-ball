using UnityEngine;

public class ObstaculoMovil : MonoBehaviour
{
    public Vector3 direccion = Vector3.right;
    public float distancia = 6f;
    public float velocidad = 3f;
    private Vector3 inicio;
    private Rigidbody rb;

    void Start()
    {
        inicio = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float d = Mathf.PingPong(Time.time * velocidad, distancia * 2);
        rb.MovePosition(inicio + direccion.normalized * d);
    }
}