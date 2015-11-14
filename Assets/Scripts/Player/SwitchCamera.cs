using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {

    [SerializeField] Camera _1stPerson;
    [SerializeField] Camera _3rdPerson;

	void Update () {
	    if (Input.GetKeyDown(KeyCode.C)) {
            Debug.Log("Input: C");
            SwitchCam();
        }
	}

    void SwitchCam() {
        if (_1stPerson.gameObject.activeSelf) {
            Debug.Log("Enable 3rd person");
            _1stPerson.gameObject.SetActive(false);
            _3rdPerson.gameObject.SetActive(true);
        } else {
            Debug.Log("Enable 1st person");
            _1stPerson.gameObject.SetActive(true);
            _3rdPerson.gameObject.SetActive(false);
        }
    }
}
