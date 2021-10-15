using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsScript : MonoBehaviour {

    bool isAlive;

    void Start() {
        isAlive = true;
    }

    void Update() {
        ParticleSystem[] MyPats = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem Stored in MyPats) {
            if (!Stored.isPlaying) {
                isAlive = false;
            }
        }
        if (!isAlive) {
            Destroy(gameObject);
        }
    }
}
