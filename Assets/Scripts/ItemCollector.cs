using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Transform _handPointPosition;

    private Item _item;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Item>(out Item item))
        {
            if (_item == null)
            {
                _item = item;
                _item.transform.SetParent(_handPointPosition);
                _item.transform.localPosition = Vector3.zero;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_item != null)
            {
                UseItem();
            }                
        }
    }

    private void UseItem()
    {
        _item.Use(gameObject);
        Destroy(_item.gameObject);
        _item = null;
    }
}
