using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player2302032054
{
    public interface IPlayer_move
    {
        static float SPEED = 1;
        float �������� => SPEED;
        GameObject ������������� { get; }
        public virtual void ��������������������(Vector3 v)
        {
        }
        public Vector3 ���������������������������������(Vector3 �����������)
        {
            var v = Vector3.MoveTowards(�������������.transform.position, �������������.transform.position + �������� * �����������, Time.deltaTime);

            �������������.transform.position = v;
            ��������������������(v);
            return v;
        }
    }
}