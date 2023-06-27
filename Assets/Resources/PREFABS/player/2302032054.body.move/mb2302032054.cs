using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player2302032054
{
    public class mb2302032054 : MonoBehaviour, IPlayer_move_input
    {
        public GameObject ИгровойОбъект { get => gameObject; }

        public IPlayer_move_input_index[] move => new IPlayer_move_input_index[] {
            new Player_move_input_index("left",KeyCode.S,Vector3.back),
            new Player_move_input_index("right",KeyCode.W,Vector3.forward),
            new Player_move_input_index("back",KeyCode.A,Vector3.left), 
            new Player_move_input_index("forward",KeyCode.D,Vector3.right),
        };

        // Update is called once per frame
        void Update()
        {
            IPlayer_move_input move_input = this;
            move_input.НажимаемНаКнопку();
        }
    }
}