using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour {

    public bool percentage = false;

    public void UpdateTextWithValue(float value) {
        if (percentage)
            GetComponent<Text>().text = value.ToString() + "%";
        else
            GetComponent<Text>().text = value.ToString("0.00");

    }
}
