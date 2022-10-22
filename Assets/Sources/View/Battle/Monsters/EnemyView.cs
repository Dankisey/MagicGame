using UnityEngine.UI;
using UnityEngine;
using Game.Model;
using Game.View;
using TMPro;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private BarView _healthView;
    [SerializeField] private Image _illustration;
    [SerializeField] private TMP_Text _name;

    private Enemy _self;

    public void Init(Enemy enemy, Sprite sprite)
    {
        _self = enemy;
        _healthView.Init(_self.Health);
        _illustration.sprite = sprite;
        _name.text = _self.Name;
    }
}