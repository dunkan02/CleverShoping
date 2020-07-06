using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductBad : Product
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.ApplayDamage(_damage);

            Destroy(gameObject);
        }
    }
}