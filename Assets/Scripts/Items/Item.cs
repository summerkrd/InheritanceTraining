using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected ParticleSystem _useEffect;

    public virtual void Use(GameObject owner)
    {
        Instantiate(_useEffect, owner.transform.position, Quaternion.identity);
    }

}
