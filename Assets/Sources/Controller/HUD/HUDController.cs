using UnityEngine;
using Game.Model;
using Game.View;

namespace Game.Controller
{
    public class HUDController : MonoBehaviour
    {   
        private Battle _currentBattle;
        private World _world;

        public void Init(World world)
        {
            _world = world;
        }
    }
}