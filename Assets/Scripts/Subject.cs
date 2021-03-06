using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour {
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField][Range(1f, 10f)] private float _speed = 5f;

    private void FixedUpdate() {
        if (Input.GetKey(KeyCode.RightArrow)) {
            this._rb.velocity = new Vector2(this._speed, this._rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            this._rb.velocity = new Vector2(-this._speed, this._rb.velocity.y);
        }
        else
            this._rb.velocity = new Vector2(0, this._rb.velocity.y);
    }
}