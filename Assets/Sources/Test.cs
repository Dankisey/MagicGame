using UnityEngine;
using Game.Model;

public class Test : MonoBehaviour
{
    private readonly Player _player = Player.Instance;
    private World _world;

    private void Start()
    {
        _world = new(Player.Instance); 
        _world.InitiateBattle();
    }

    public void OnAttackButtonPushed()
    {
        _player.AttackPerformer.Perform(1);
    }
}