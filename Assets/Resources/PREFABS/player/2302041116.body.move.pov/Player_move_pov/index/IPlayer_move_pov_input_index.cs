using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player2302041116
{
    using Player2302032054;
    public interface IPlayer_move_pov_input_index: IPlayer_move_input_index
    {
        IPlayer_move_pov_input ������������������� { get; set; }
        /// <summary>
        /// ����������� 0-3 (�ר� ������ ������ ��������)
        /// ������ - ����� - ����� - ��
        /// </summary>
        KeyCode[] ��������������4 { get; }
        public new KeyCode �������������� { get => ��������������4[�������������������.��������������]; }
    }
}