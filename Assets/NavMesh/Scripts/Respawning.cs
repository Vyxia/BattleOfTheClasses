using UnityEngine;
using System.Collections;

public class Respawning : MonoBehaviour {

    [SerializeField]
    GameObject respawnPoint;

    public void Respawn() {
        transform.position = respawnPoint.transform.position;
    }
}
