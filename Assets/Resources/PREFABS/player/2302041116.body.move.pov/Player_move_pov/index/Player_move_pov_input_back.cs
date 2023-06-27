using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player2302041116
{
    using Player2302032054;
    public class Player_move_pov_input_back : Player_move_input_index, IPlayer_move_pov_input_index
    {
        public Player_move_pov_input_back(string name, KeyCode btn, Vector3 direction):base(name, btn, direction)
        {
        }
        static public readonly KeyCode[] btns4 = new KeyCode[4] { KeyCode.A, KeyCode.W, KeyCode.D, KeyCode.S };
        #region pov
        private IPlayer_move_pov_input pov;
        public IPlayer_move_pov_input ”правлениеѕоворотом { get => pov; set => pov=value; }

        //public Player_move_pov_input_back(IPlayer_move_pov_input pov)=>this.pov = pov;
        #endregion
        public KeyCode[]  нопкиƒвижений4 => btns4;
    }
}