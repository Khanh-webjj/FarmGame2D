using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.FantasyMonsters.Scripts
{
    /// <summary>
    /// Demo scene that can run animations.
    /// </summary>
    public class Demo : MonoBehaviour
    {
        private List<Monster> Monsters => FindObjectsOfType<Monster>().ToList();

        public void Start()
        {
            Monsters.ForEach(i => i.SetState(MonsterState.Ready));
        }

        public void PlayAnimation(string clipName)
        {
            Monsters.ForEach(i => i.SetState((MonsterState) Enum.Parse(typeof(MonsterState), clipName)));
        }

        public void Attack()
        {
            Monsters.ForEach(i => i.Attack());
        }

        public void SetTrigger(string trigger)
        {
            Monsters.ForEach(i => i.Animator.SetTrigger(trigger));
        }

        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void OpenURL(string url)
        {
            Application.OpenURL(url);
        }
    }
}