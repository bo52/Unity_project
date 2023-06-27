using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player2302032054
{
    public interface IPlayer_move_input_index
    {
        string Имя { get; }
        Vector3 Направление { get; }
        KeyCode КнопкаДвижения { get; set; }
    }
}