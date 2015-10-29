﻿using UnityEngine;
using System.Collections;

public class ParticleSortingLayerFix : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GetComponent<ParticleSystemRenderer>().sortingLayerName = "Player";
        GetComponent<ParticleSystemRenderer>().sortingOrder = -1;
    }
}
