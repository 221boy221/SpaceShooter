using UnityEngine;
using System.Collections;

public class Rocket : Ammunition {
    //
    void Start() {
        Destroy(gameObject, 10.0f);
    }
    
}
