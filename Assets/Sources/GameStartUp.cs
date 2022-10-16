using Game.Controller;
using Game.Model;
using UnityEngine;

public sealed class GameStartUp : MonoBehaviour
{
    [SerializeField] private FactoriesInitializer _initializer;

    private readonly Player _player = Player.Instance;
    private World _world;

    private void Awake()
    {
        _initializer.Init(_player);
        _player.ResetAttackPerformer();
        _world = new(Player.Instance); 
        _world.InitiateBattle();
    }
}