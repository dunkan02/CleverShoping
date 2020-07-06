using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LastProduct : MonoBehaviour
{
    private int _index;

    public int Index => _index;
    public event UnityAction<int> Deleted;
    
    public void Init(int index)
    {
        _index = index;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player) || 
            collision.TryGetComponent<DeleteProducts>(out DeleteProducts deleteProducts))
        {
            Deleted?.Invoke(_index);
        }
    }
}