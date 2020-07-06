using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckerLastProduct : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Player _player;
    [SerializeField] public int _counterLastProducts;

    private Product[] _products;

    public event UnityAction<int, int> AllProductFinished;

    private void OnEnable()
    {
        _spawner.AllProductSpawnedInWave += CheckFallingProduct;
    }

    private void OnDisable()
    {
        _spawner.AllProductSpawnedInWave -= CheckFallingProduct;
    }

    public void CheckFallingProduct(int indexWave, int countWave)
    {
        if (indexWave == countWave - 1)
        {
            _products = FindObjectsOfType<Product>();
            for (int i = 0; i < _products.Length; i++)
            {
                _products[i].gameObject.AddComponent<LastProduct>();
                _products[i].GetComponent<LastProduct>().Init(i);
                _products[i].GetComponent<LastProduct>().Deleted += LastProductDeleted;
            }
            _counterLastProducts = _products.Length;
        }
    }

    private void LastProductDeleted(int index)
    {
        if(_products[index]!= null)
            _products[index].GetComponent<LastProduct>().Deleted -= LastProductDeleted;

        _counterLastProducts--;

        if (_counterLastProducts <= 0)
        {
            AllProductFinished?.Invoke(_player.Health, _player.Money);
        }
    }
}