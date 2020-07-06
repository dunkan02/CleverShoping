using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _leftPosition;
    [SerializeField] private Transform _rightPosition;
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private List<GameObject> _goodTemplates;
    [SerializeField] private List<GameObject> _badTemplates;

    private float _zCoordinate;
    private float _xLeftPosition;
    private float _xRightPosition;
    private Wave _currentWave;
    private int _currentWaveIndex = 0;
    private List<int> _markerProducts = new List<int>();
    private int _counterSpawnedProduct = 0;
    private int _counterSpawnedGoodProduct = 0;
    private int _counterSpawnedBadProduct = 0;
    private float _timeStamp;

    public event UnityAction<int, int> SpawnedGoodProduct;
    public event UnityAction<int, int> SpawnedBadProduct;
    public event UnityAction<int, int> AllProductSpawnedInWave;

    private void Start()
    {
        _zCoordinate = _player.transform.position.z;
        _xLeftPosition = _leftPosition.position.x;
        _xRightPosition = _rightPosition.position.x;

        SetWave(0);
    }

    private void Update()
    {
        if (Time.time - _timeStamp > _currentWave.Delay)
        {
            if (_markerProducts.Count - 1 >= _counterSpawnedProduct)
            {
                Spawn(_markerProducts[_counterSpawnedProduct]);
                switch (_markerProducts[_counterSpawnedProduct])
                {
                    case 0:
                        _counterSpawnedBadProduct++;
                        SpawnedBadProduct?.Invoke(_counterSpawnedBadProduct, _currentWave.CountBadProducts);
                        break;
                    case 1:
                        _counterSpawnedGoodProduct++;
                        SpawnedGoodProduct?.Invoke(_counterSpawnedGoodProduct, _currentWave.CountGoodProducts);
                        break;
                    default:
                        break;
                }
            }
            _timeStamp = Time.time;
            _counterSpawnedProduct++;

            if (_counterSpawnedProduct == _markerProducts.Count)
            {
                AllProductSpawnedInWave?.Invoke(_currentWaveIndex, _waves.Count);
            }
        }
    }

    public void NextWave()
    {
        _currentWaveIndex++;
        if (_currentWaveIndex > _waves.Count - 1)
        {
            return;
        }

        SetWave(_currentWaveIndex);
    }

    private void Spawn(int typeProduct)
    {
        float xCoordinate = Random.Range(_xLeftPosition, _xRightPosition);
        switch (typeProduct)
        {
            case 0:
                Instantiate(GetRandomProduct(typeProduct), new Vector3(xCoordinate, transform.position.y, _zCoordinate), Quaternion.identity);
                break;
            case 1:
                Instantiate(GetRandomProduct(typeProduct), new Vector3(xCoordinate, transform.position.y, _zCoordinate), Quaternion.identity);
                break;
            default:
                return;
        }
    }

    private void Shuffle()
    {
        for (int i = 0; i < _markerProducts.Count; i++)
        {
            int temp = _markerProducts[i];
            int randomIndex = Random.Range(i, _markerProducts.Count);
            _markerProducts[i] = _markerProducts[randomIndex];
            _markerProducts[randomIndex] = temp;
        }
    }

    private GameObject GetRandomProduct(int typeProduct)
    {
        List<GameObject> listGameObject = new List<GameObject>();
        switch (typeProduct)
        {
            case 0:
                listGameObject = _badTemplates;
                break;
            case 1:
                listGameObject = _goodTemplates;
                break;
            default:
                break;
        }

        int randomIndex = Random.Range(0, listGameObject.Count);
        return listGameObject[randomIndex];
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        _markerProducts.Clear();

        for (int i = 0; i < _currentWave.CountBadProducts; i++)
        {
            _markerProducts.Add(0);
        }

        for (int i = 0; i < _currentWave.CountGoodProducts; i++)
        {
            _markerProducts.Add(1);
        }

        Shuffle();

        _counterSpawnedBadProduct = 0;
        _counterSpawnedGoodProduct = 0;
        _counterSpawnedProduct = 0;
    }

    public float GetProgressWaveNormalize()
    {
        return (float)(_currentWaveIndex + 1) / _waves.Count ;
    }
}

[System.Serializable]
public class Wave
{
    
    public float Delay;
    public int CountGoodProducts;
    public int CountBadProducts;
}