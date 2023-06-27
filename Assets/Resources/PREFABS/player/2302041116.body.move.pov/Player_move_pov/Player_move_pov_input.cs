using Player2302032054;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player2302041116
{
    public class Player_move_pov_input :MonoBehaviour, IPlayer_move_pov_input
    {
        public GameObject ИгровойОбъект => gameObject;
        private int pov = 0;
        public int ИндексПоворота { get => pov; set => pov=value; }
        public IPlayer_move_input_index[] move => new IPlayer_move_input_index[] { };


    }
}