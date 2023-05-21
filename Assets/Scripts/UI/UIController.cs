using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VillageAdventure.Object;

namespace VillageAdventure
{
    public class UIController : MonoBehaviour
    {
        public RectTransform currentGauge;
        public RectTransform lifeBar;

        public Text time;
        public Text mine;
        public Text tree;
        public Text food;
        public Text fish;
        public Text score;
        public GameObject playerHP;


        private void Start()
        {

        }
        private void Update()
        {
            DisplayTime();
            ObjectCount();
            ScoreCount();
            CalculateLifeGauge();
        }

        private void DisplayTime()
        {
            time.text = $"Time [{InGameManager.Instance.hour} : {Mathf.Floor(InGameManager.Instance.min/60)}]";
        }

        private void ObjectCount()
        {
            mine.text = $": {InGameManager.Instance.mine}";
            tree.text = $": {InGameManager.Instance.tree}";
            food.text = $": {InGameManager.Instance.food}";
            fish.text = $": {InGameManager.Instance.fish}";
        }

        private void ScoreCount()
        {
            score.text = $"Score : {InGameManager.Instance.score}";
        }

        private void CalculateLifeGauge()
        {
            // ���� ü���� ��Ÿ���� ĳ���� �̹����� ���� ��ġ�� �޾ƿ�
            Vector2 position = currentGauge.anchoredPosition;
            // ������ 0%, ������ 100%�� ���̵��� ĳ���� �̹����� x ��ġ�� ����
            /// �÷��̾��� ����� ���� 100�� ���� �ʵ��� (����� �� ���� 0~100)
            position.x = lifeBar.sizeDelta.x * (InGameManager.Instance.playerHP / 100) - 150f;
            // ������ ��ġ�� ����
            currentGauge.anchoredPosition = position;
        }
    }
}