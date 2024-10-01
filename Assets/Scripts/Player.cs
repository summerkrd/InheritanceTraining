using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 5;

    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }

    private void Start()
    {
        Debug.Log($"Здоровье игрока {_health} единиц");
    }
}
