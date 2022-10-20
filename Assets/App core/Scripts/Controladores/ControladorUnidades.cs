using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorUnidades : MonoBehaviour
{
    [System.Serializable]
    public class mundos
    {
        public string name;
        public int id_num;
        public List<unidad> Unidades;
    }

    [System.Serializable]
    public class unidad
    {
        public string name;
        public int id_num;
        public bool check;
        public bool epidosio;
        public List<gamesUnid> id;
    }

    [System.Serializable]
    public class gamesUnid
    {
        public string name;
        public string id;
        public int id_num;
        public Sprite imgBut;

        public enum tipo { Juego, Video }
        public tipo clase = tipo.Juego;

        public bool check;
    }


}




