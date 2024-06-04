using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 localPosition;
    public Quaternion localRotation;

    /*On prends la position des cerises*/
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        localPosition = transform.localPosition;
        localRotation = transform.localRotation;
    }

    /*Procède au reset des cerises sur l'arbre*/
    public void Reset()
    {
        transform.localPosition = localPosition;
        transform.localRotation = localRotation;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
    }

    /*Fait tomber les cerises*/
    public void FallFonction()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
