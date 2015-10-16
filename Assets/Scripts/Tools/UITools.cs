using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Boy Voesten
// This class contains useful functions that can be executed by the Unity UI via the Inspector

public class UITools : MonoBehaviour {
    
    [SerializeField]
    private Settings _settings;

    public void UpdateUISettings(GameObject obj) {
        switch (obj.tag) {
            case TagList.MouseSlider:
                obj.GetComponent<Slider>().value = _settings.mouseSens;
                break;
            case TagList.AudioSlider:
                obj.GetComponent<Slider>().value = _settings.audioVolume;
                break;
            default:
                break;
        }
        
    }

    public void LoadScene(string scene) {
        Application.LoadLevel(scene);
    }

    public void ToggleActive(GameObject obj) {
        obj.SetActive(!obj.activeSelf);
    }
}
