using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player2302032054
{
    /// <summary>
    /// игрок движется от глуби
    /// </summary>
    public class Player_move_input_left
    {
        private KeyCode btn = KeyCode.S;
        public KeyCode КнопкаДвижения { get => btn; set => btn = value; }
        static readonly Vector3 direction = Vector3.back;
        public Vector3 Направление => direction;
    }
}
