using UnityEngine;
using Game.Model;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private World _world;

    private void Start()
    {
        _world = new(Player.Instance); 
        _world.InitiateBattle();
    }

    public void OnAttackButtonPushed()
    {
        Player.Instance.AttackFactory.Perform(_world.CurrentBattle.Target);
    }
}
