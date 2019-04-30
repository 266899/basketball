namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRTK.Controllables;
    using VRTK.Controllables.PhysicsBased;

    public class ControllableReactor : MonoBehaviour
    {
        public GameObject wall;
        public GameObject timerText;
        public GameObject scoreText;
        public float timeLeft;
        public VRTK_BaseControllable controllable;
        public Text displayText;
        public string outputOnMax = "Maximum Reached";
        public string outputOnMin = "Minimum Reached";
        bool timerStarted = false;


        protected virtual void OnEnable()
        {
            controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
            controllable.ValueChanged += ValueChanged;
            if (timeLeft < 0)
            {
                controllable.MaxLimitReached -= MaxLimitReached;
            }
                controllable.MaxLimitReached += MaxLimitReached;
            controllable.MinLimitReached += MinLimitReached;
        }

        protected virtual void ValueChanged(object sender, ControllableEventArgs e)
        {
            if (displayText != null)
            {
                displayText.text = e.value.ToString("F1");
            }
        }

        protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
        {
            if (outputOnMax != "")
            {
                VRTK_PhysicsPusher.stayPressed = true;
                timerText.GetComponent<Text>().text = timeLeft.ToString();
                wall.SetActive(false);
                if (!timerStarted)timerStarted = true;
                int score = 0;
                scoreText.GetComponent<Text>().text = score.ToString();
            }
        }

        protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
        {
            if (outputOnMin != "")
            {
                Debug.Log(outputOnMin);
            }
        }

        void Update() {
            if (timerStarted)
            {
                timeLeft -= Time.deltaTime;
                timerText.GetComponent<Text>().text = timeLeft.ToString("F2");
                if (timeLeft <= 0)
                {
                    timeLeft = 60f;
                    timerStarted = false;
                    wall.SetActive(true);
                    timerText.GetComponent<Text>().text = timeLeft.ToString();
                    VRTK_PhysicsPusher.stayPressed = false;


                }
            }
        }
    }
}