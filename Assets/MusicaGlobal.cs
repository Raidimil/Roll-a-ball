using UnityEngine;

public class MusicaGlobal : MonoBehaviour
{
    static MusicaGlobal instancia;

    void Awake()
    {
        if (instancia != null)
        {
            Destroy(gameObject);
            return;
        }
        instancia = this;
        DontDestroyOnLoad(gameObject);
    }
}
