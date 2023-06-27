using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player2302032054
{
    /// <summary>
    /// игрок движется назад
    /// </summary>
    public class Player_move_input_index : IPlayer_move_input_index
    {
        private string _name = "left";
        protected KeyCode _btn = KeyCode.A;
        private Vector3 _direction = Vector3.left;
        public Player_move_input_index(string name, KeyCode btn,Vector3 direction)
        {
            _name = name;
            _btn = btn;
            _direction = direction;
        }
        public virtual KeyCode КнопкаДвижения { get => _btn; set => _btn = value; }
        public Vector3 Направление => _direction;
        public string Имя => _name;
    }
}
