using UnityEngine;
using System;

namespace Game.Controller
{
    public class PlayerBiomeHandler : MonoBehaviour
    {
        public Action<Biome> NewBiomeEntered;

        public void EnterNewBiome(Biome biome)
        {
            NewBiomeEntered?.Invoke(biome);
        }
    }
}