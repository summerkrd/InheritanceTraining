using UnityEngine;

public class BulletItem : Item
{
    [SerializeField] private BulletPrefab _bulletPrefab;
    [SerializeField] private float _shootForce;

    private HandPoint _handPoint;

    public override void Use(GameObject owner)
    {
        _handPoint = owner.GetComponentInChildren<HandPoint>();

        base.Use(owner);

        if (_handPoint != null)
        {
            BulletPrefab bulletPrefab = Instantiate(_bulletPrefab, _handPoint.transform.position, Quaternion.identity);

            Rigidbody rigidbody = bulletPrefab.GetComponent<Rigidbody>();
            rigidbody.AddForce(_handPoint.transform.forward * _shootForce, ForceMode.Impulse);
        }
    }
}
