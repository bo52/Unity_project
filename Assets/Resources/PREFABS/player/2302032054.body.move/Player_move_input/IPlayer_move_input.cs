using UnityEngine;

namespace Player2302032054
{
    public interface IPlayer_move_input : IPlayer_move
    {
        IPlayer_move_input_index[] move { get; }
        public IPlayer_move_input_index �������������������
        {
            get
            {
                for (sbyte i = 0; i < move.Length; i++)
                    if (Input.GetKey(move[i].��������������))
                        return move[i];
                return null;
            }
        }
        public bool ����������������()
        {
            var index = �������������������;
            if (index == null) return false;
            ���������������������������������(index.�����������);
            return true;
        }
        public bool ���������������������� => ����������������();
    }
}
