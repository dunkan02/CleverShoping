using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteProducts : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Product>(out Product product))
        {
            Destroy(product.gameObject);
        }
    }
}