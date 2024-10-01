using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HealItem : Item
{    
    private int _healingValue = 5;
    private Player _player;

    public override void Use(GameObject owner)
    {
        if (owner.TryGetComponent<Player>(out _player))
        {
            base.Use(owner);
            _player.Health += _healingValue;
            Debug.Log($"Здоровье игрока {_player.Health} единиц");
        }                
    }
}
