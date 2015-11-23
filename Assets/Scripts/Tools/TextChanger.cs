using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Boy Voesten

public class TextChanger : MonoBehaviour {

    public bool percentage = false;

    public void UpdateTextWithFloat(float value) {
        if (percentage)
            GetComponent<Text>().text = value.ToString() + "%";
        else
            GetComponent<Text>().text = value.ToString("0.00");
    }
    /*
    public void UpdateTextWithString(string str) {
        GetComponent<Text>().text = str;
    }
    */
}
