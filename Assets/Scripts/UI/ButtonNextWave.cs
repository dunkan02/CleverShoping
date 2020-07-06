using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNextWave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _buttonNextWave;
    [SerializeField] private GameObject _containerButtonWave;

    private void OnEnable()
    {
        _spawner.AllProductSpawnedInWave += OnAllProductSpawnedInWave;
        _buttonNextWave.onClick.AddListener(OnButtonNextWaveClick);
    }

    private void OnDisable()
    {
        _buttonNextWave.onClick.RemoveListener(OnButtonNextWaveClick);
        _spawner.AllProductSpawnedInWave -= OnAllProductSpawnedInWave;
    }

    private void OnAllProductSpawnedInWave(int indexWave, int countWave)
    {
        if (indexWave <= countWave - 2)
        {
            _containerButtonWave.SetActive(true);
            _buttonNextWave.GetComponent<Image>().fillAmount = _spawner.GetProgressWaveNormalize();
        }
    }

    private void OnButtonNextWaveClick()
    {
        _containerButtonWave.SetActive(false);
        _spawner.NextWave();
    }
}