using UnityEngine;
using System.Collections;

// Boy Voesten

public class Settings : MonoBehaviour
{

    public float mouseSensitivity { get; set; }
    public float audio { get; set; }
    private bool _spawned = false;

    void Start()
    {
        if (!_spawned)
        {
            _spawned = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

}
