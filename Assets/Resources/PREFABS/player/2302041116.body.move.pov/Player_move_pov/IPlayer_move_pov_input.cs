using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player2302041116
{
    using Player2302032054;
    public interface IPlayer_move_pov_input : IPlayer_move_input
    {
        int ИндексПоворота { get; set; }
        public IPlayer_move_pov_input_index move_pov(int i)=>move[i] as IPlayer_move_pov_input_index;
    }
}