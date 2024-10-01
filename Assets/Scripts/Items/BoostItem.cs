using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BoostItem : Item
{
    [SerializeField] private float _boostMultiplier = 2f;
    private PlayerMove _playerMove;

    public override void Use(GameObject owner)
    {
        if (owner.TryGetComponent<PlayerMove>(out _playerMove))
        {
            base.Use(owner);
            _playerMove.MoveSpeed *= _boostMultiplier;
            Debug.Log($"Скорость игрока {_playerMove.MoveSpeed}");
        }
    }
}

