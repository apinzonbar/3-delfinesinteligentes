using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SkateScamper.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        
        public GameState CurrentState = GameState.Idle;
        public float countdownDuration = 3f;
        public List<PlayerController> players = new List<PlayerController>();

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        private void Start()
        {
            StartCoroutine(StartGameSequence());
        }

        private IEnumerator StartGameSequence()
        {
            CurrentState = GameState.Countdown;
            yield return new WaitForSeconds(countdownDuration);
            CurrentState = GameState.Racing;
            foreach (var player in players) player.SetInputEnabled(true);
        }
    }
}