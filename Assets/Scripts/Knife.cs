﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Knife : MonoBehaviour {

    [SerializeField]
    private float speed;

    private Rigidbody2D myRigidbody;

    private Vector2 direction;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
	
	
	void FixedUpdate () {
        myRigidbody.velocity = direction * speed;
	}

    // Update is called once per frame
    void Update() {

    }

    public void Initialize(Vector2 direction){
        this.direction = direction;
    }

    //To remove knifes that gets out the camera view
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
