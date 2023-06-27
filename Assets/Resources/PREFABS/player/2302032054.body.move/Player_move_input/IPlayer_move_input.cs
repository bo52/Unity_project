using UnityEngine;

namespace Player2302032054
{
    public interface IPlayer_move_input : IPlayer_move
    {
        IPlayer_move_input_index[] move { get; }
        public IPlayer_move_input_index ИндексНажатияКнопки
        {
            get
            {
                for (sbyte i = 0; i < move.Length; i++)
                    if (Input.GetKey(move[i].КнопкаДвижения))
                        return move[i];
                return null;
            }
        }
        public bool НажимаемНаКнопку()
        {
            var index = ИндексНажатияКнопки;
            if (index == null) return false;
            НовоеПоложениеИгрокаПоНаправлению(index.Направление);
            return true;
        }
        public bool СовершилиНажатиеКнопки => НажимаемНаКнопку();
    }
}
