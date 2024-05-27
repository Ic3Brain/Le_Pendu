using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Unity.VisualScripting;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //FreezeXAndYConstraintsCherry();
        UnFreezeConstraintsCherry();
    }

    public void FreezeXAndYConstraintsCherry()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
    }
    public void UnFreezeConstraintsCherry()
    {
        rb.constraints = ~RigidbodyConstraints2D.FreezePosition;
    }
}
