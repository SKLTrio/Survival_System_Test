using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class Fuzzy : MonoBehaviour
{
    private const string label_text = "{0} true";
    public AnimationCurve starving;
    public AnimationCurve hungry;
    public AnimationCurve stomach_full;

    public Slider hunger_input;

    public Text stomach_full_label;
    public Text hungry_label;
    public Text starving_label;

    private float starving_value = 0f;
    private float hungry_value = 0f;
    private float stomach_full_value = 0f;

    void Start()
    {
        Set_Labels();
    }

    void Update()
    {
        EvaluateStatements();
    }

    private void EvaluateStatements()
    {
        float input_value = hunger_input.value;

        stomach_full_value = stomach_full.Evaluate(input_value);
        hungry_value = hungry.Evaluate(input_value);
        starving_value = starving.Evaluate(input_value);

        Set_Labels();

    }

    private void Set_Labels()
    {
        stomach_full_label.text = string.Format(label_text, stomach_full_value);
        hungry_label.text = string.Format(label_text, hungry_value);
        starving_label.text = string.Format(label_text, starving_value);
    }
}
