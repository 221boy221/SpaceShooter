using UnityEngine;
using System.Collections;

// Boy Voesten

public class UITools : MonoBehaviour
{

    public void LoadScene(string scene)
    {
        Application.LoadLevel(scene);
    }

    public void ToggleActive(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }
}
