using System.Collections.Generic;
using UnityEngine;
using Game.View;

namespace Game.Controller
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] HUDPanel _mainPanel;

        void Start()
        {
            _mainPanel.Open();
        }
    }
}