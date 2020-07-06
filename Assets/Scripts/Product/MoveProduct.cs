using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Product))]
public class MoveProduct : MonoBehaviour
{
    private Product _product;
    private float _speed;
    private void Start()
    {
        _product = GetComponent<Product>();
        _speed = _product.Speed;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }
}
