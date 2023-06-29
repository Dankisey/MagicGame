using System.Collections.Generic;
using UnityEngine;
using Game.View;

namespace Game.Controller
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] List<HUDPanel> _mainPanels;

        void Start()
        {
            foreach (var panel in _mainPanels)
            {
                panel.Open();
                panel.CloseOthers();
            }
        }
    }
}