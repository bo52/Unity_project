using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player2302032054
{
    /// <summary>
    /// ����� �������� ������
    /// </summary>
    public class Player_move_input_right
    {
        private KeyCode btn = KeyCode.W;
        public KeyCode �������������� { get => btn; set => btn = value; }
        static readonly Vector3 direction = Vector3.forward;
        public Vector3 ����������� => direction;
    }
}
