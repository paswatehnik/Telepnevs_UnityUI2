using UnityEngine;
using TMPro;
using System;

public class AgeCalculator : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField yearInput;
    public TMP_Text resultText;

    public void CalculateAge()
    {
        if (string.IsNullOrEmpty(nameInput.text) || string.IsNullOrEmpty(yearInput.text))
        {
            resultText.text = "Enter your name and year of birth!";
            return;
        }

        if (!int.TryParse(yearInput.text, out int birthYear))
        {
            resultText.text = "A year should be a number!";
            return;
        }

        int currentYear = DateTime.Now.Year;
        int age = currentYear - birthYear;

        if (age < 0)
        {
            resultText.text = "The year of birth can't be in the future!";
        }
        else if (age > 120)
        {
            resultText.text = $"{nameInput.text}, Are you sure you're {age} years old?";
        }
        else
        {
            resultText.text = $"{nameInput.text}, age: {age} years";
        }
    }
}