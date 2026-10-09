using UnityEngine;

public class GeneradorLinea : MonoBehaviour
{
    public GameObject prefab;
    public int cantidad = 8;
    public Vector3 inicio = new Vector3(-6f, 0.5f, 0f);
    public Vector3 paso = new Vector3(1.7f, 0f, 0f);
    public float zigzag = 0f;

    void Awake()
    {
        for (int i = 0; i < cantidad; i++)
        {
            Vector3 pos = inicio + paso * i;
            if (zigzag != 0f)
            {
                pos.z += (i % 2 == 0) ? zigzag : -zigzag;
            }
            Instantiate(prefab, pos, Quaternion.identity, transform);
        }
    }
}