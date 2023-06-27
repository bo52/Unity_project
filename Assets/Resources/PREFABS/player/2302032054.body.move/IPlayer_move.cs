using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player2302032054
{
    public interface IPlayer_move
    {
        static float SPEED = 1;
        float Скорость => SPEED;
        GameObject ИгровойОбъект { get; }
        public virtual void НовоеПоложениеИгрока(Vector3 v)
        {
        }
        public Vector3 НовоеПоложениеИгрокаПоНаправлению(Vector3 Направление)
        {
            var v = Vector3.MoveTowards(ИгровойОбъект.transform.position, ИгровойОбъект.transform.position + Скорость * Направление, Time.deltaTime);

            ИгровойОбъект.transform.position = v;
            НовоеПоложениеИгрока(v);
            return v;
        }
    }
}