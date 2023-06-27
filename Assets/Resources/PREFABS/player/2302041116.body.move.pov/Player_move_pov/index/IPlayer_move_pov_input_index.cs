using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player2302041116
{
    using Player2302032054;
    public interface IPlayer_move_pov_input_index: IPlayer_move_input_index
    {
        IPlayer_move_pov_input УправлениеПоворотом { get; set; }
        /// <summary>
        /// направление 0-3 (УЧЁТ четырёх сторон поворота)
        /// Восток - Север - Запад - Юг
        /// </summary>
        KeyCode[] КнопкиДвижений4 { get; }
        public new KeyCode КнопкаДвижения { get => КнопкиДвижений4[УправлениеПоворотом.ИндексПоворота]; }
    }
}