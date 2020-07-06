using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    [SerializeField] protected float SpeedProduct;

    public float Speed => SpeedProduct;
}