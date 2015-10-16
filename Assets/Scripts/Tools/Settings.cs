using UnityEngine;
using System.Collections;

// Boy Voesten

public class Settings : MonoBehaviour {

    private float _mouseSens = 2.0f;
    private float _audioVolume = 100.0f;
    private bool _spawned = false;

    // For the UI to GET/SET
    public float mouseSens { get { return _mouseSens; } set { _mouseSens = value; } }
    public float audioVolume { get { return _audioVolume; } set { _audioVolume = value; } } 

    void Start() {
        if (!_spawned) {
            _spawned = true;
            DontDestroyOnLoad(gameObject);
        } else {
            DestroyImmediate(gameObject);
        }
        LoadSettings();
    }

    public void SaveSettings() {
        Debug.Log("Saving...");
        Debug.Log(_mouseSens);
        Debug.Log(_audioVolume);
        PlayerPrefs.SetFloat("mouseSens", _mouseSens);
        PlayerPrefs.SetFloat("audioVolume", _audioVolume);
        Debug.Log("Saved");
    }

    public void LoadSettings() {
        Debug.Log("Loading...");
        _mouseSens = PlayerPrefs.GetFloat("mouseSens");
        _audioVolume = PlayerPrefs.GetFloat("audioVolume");
        Debug.Log(_mouseSens);
        Debug.Log(_audioVolume);
        Debug.Log("Loaded");
    }

}




// Failed attempt on saving the data in an XML file.. (Might come back to this later)

/*
[XmlRoot("Settings")]
public class Settings
{
    [XmlAttribute("sensitivity")]
    public float mouseSensitivity { get; set; }
    [XmlAttribute("audio")]
    public float audio { get; set; }
    
    public string filePath = Application.persistentDataPath + "/settings.xml";

    

    public void SaveSettings() {
        XmlSerializer serializer = new XmlSerializer(typeof(Settings));
        FileStream file = new FileStream(filePath, FileMode.Create);
        serializer.Serialize(file, this);
        file.Close();
    }

    public void LoadSettings() {
        XmlSerializer serializer = new XmlSerializer(typeof(Settings));
        FileStream file = new FileStream(filePath, FileMode.Open);
        Settings container = serializer.Deserialize(file) as Settings;
    }
}
*/