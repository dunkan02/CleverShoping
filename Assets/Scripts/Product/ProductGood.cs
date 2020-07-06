using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductGood : Product
{
    [SerializeField] private int _reward;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.AddMoney(_reward);

            Destroy(gameObject);
        }
    }
}