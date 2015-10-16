using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game {

    public static Game current;
    public PlayerShip playerShip;

    public Game() {
        playerShip = new PlayerShip();
    }
}
