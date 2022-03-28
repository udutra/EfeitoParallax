using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxable : MonoBehaviour {
    
    [Header("Needed Objects")]
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _subject;

    [Header("Config")]
    [SerializeField] private bool lockY = false;
    [SerializeField] private bool lockX = false;
    [SerializeField][Range(0.1f, 2f)] private float _smoothingFactor;

    private Vector3 _startingPos;

    private float TravelX => this._camera.transform.position.x - this._startingPos.x;
    private float TravelY => this._camera.transform.position.y - this._startingPos.y;

    // Parallax Factor

    private float DistanceFromSubject => this._startingPos.z - this._subject.transform.position.z;
    private float ClipPlane => this._camera.transform.position.z + (this.DistanceFromSubject > 0 ? this._camera.farClipPlane : -this._camera.nearClipPlane);
    private float ParallaxFactor => Mathf.Abs(this.DistanceFromSubject) / this.ClipPlane;

    private float NewX => this.lockX ? this._startingPos.x : this._startingPos.x + (this.TravelX * this.ParallaxFactor * this._smoothingFactor);
    private float NewY => this.lockY ? this._startingPos.y : this._startingPos.y + (this.TravelY * this.ParallaxFactor * this._smoothingFactor);


    private void Start() {
        this._startingPos = transform.position;
    }

    private void FixedUpdate() {
        this.transform.position = new Vector3(this.NewX, this.NewY, this._startingPos.z);
    }
}