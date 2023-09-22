using System;
using UnityEngine;

namespace UI.Dialogs
{
    [Serializable]
    public struct DialogData
    {
        [SerializeField] private Sentence[] _sentences;
        public Sentence[] Sentence => _sentences;
    }

    [Serializable]
    public struct Sentence
    {
        [SerializeField] private string _valued;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Side _side;

        public string Value => _valued;
        public Sprite Icon => _icon;
        public Side Side => _side;
    }

    public enum Side
    {
        Left,
        Right
    }
}