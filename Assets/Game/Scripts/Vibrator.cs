using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

using distriqt.plugins.vibration;




public class Vibrator : MonoBehaviour
{

    private FeedbackGenerator _selectGenerator;
    private FeedbackGenerator _impactGenerator;

    public void VibrateLight()
    {
        if (Vibration.isSupported)
        {

            if (PlayerPrefs.HasKey("Vibration"))
            {
                if (PlayerPrefs.GetInt("Vibration") == 1)
                {
                    if (_selectGenerator == null)
                    {
                        _selectGenerator = Vibration.Instance.CreateFeedbackGenerator(FeedbackGeneratorType.SELECTION);
                    }
                    _selectGenerator.PerformFeedback();

                }
            }
        }
    }

    public void VibrateHard()
    {
        if (Vibration.isSupported)
        {

            if (PlayerPrefs.HasKey("Vibration"))
            {
                if (PlayerPrefs.GetInt("Vibration") == 1)
                {
                    if (_impactGenerator == null)
                    {
                        _impactGenerator = Vibration.Instance.CreateFeedbackGenerator(FeedbackGeneratorType.IMPACT);
                        _impactGenerator.Prepare();
                    }
                    _impactGenerator.PerformFeedback();

                }
            }

        }



    }



}


