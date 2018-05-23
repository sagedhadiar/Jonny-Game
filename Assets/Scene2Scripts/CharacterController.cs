﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour {

    [SerializeField]
    protected Transform KnifePos;

    [SerializeField]
    protected GameObject KnifePrefab;

    [SerializeField]
    protected float movementSpeed;

    protected bool facingRight;

    public bool Attack { get; set; }

    public bool TakingDamage { get; set; }

    [SerializeField]
    protected int health;

    [SerializeField]
    private EdgeCollider2D SwordCollider;

    [SerializeField]
    private List<string> damageSources;

    public abstract bool isDead { get; }

    public Animator MyAnimator { get; private set; }

    // Use this for initialization
    public virtual void Start() {

        facingRight = true;

        MyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }

    public abstract IEnumerator TakeDamage();

    public void ChangeDirection() {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }

    public virtual void ThrowKnife(int value) {
        if (facingRight) {
            GameObject tmp = (GameObject)Instantiate(KnifePrefab, KnifePos.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            tmp.GetComponent<Knife>().Initialize(Vector2.right);
        }
        else {
            GameObject tmp = (GameObject)Instantiate(KnifePrefab, KnifePos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            tmp.GetComponent<Knife>().Initialize(Vector2.left);
        }
    }

    public void MeleeAttack() {
        SwordCollider.enabled = !SwordCollider.enabled;

    }

    public virtual void OnTriggerEnter2D(Collider2D other) {
        //Using 2 tags revent the player from hitting himself
        if (damageSources.Contains(other.tag)) {
            StartCoroutine(TakeDamage());
        }

    }

    

}
