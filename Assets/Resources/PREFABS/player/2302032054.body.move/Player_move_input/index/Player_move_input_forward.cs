using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player2302032054
{
    /// <summary>
    /// игрок движется вперёд
    /// </summary>
    public class Player_move_input_forward 
    {
        private KeyCode btn = KeyCode.D;
        public KeyCode КнопкаДвижения { get => btn; set => btn = value; }
        static readonly Vector3 direction = Vector3.right;
        public Vector3 Направление => direction;
    }
}
