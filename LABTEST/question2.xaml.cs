namespace LABTEST;

public partial class question2 : ContentPage
{
    public question2()
    {
        InitializeComponent();

        //PREPARE INPUT
        PhoneEntry.TextChanged += EntryTextChanged;
        PasswordEntry.TextChanged += EntryTextChanged;
        TermsAndConditionCheckbox.CheckedChanged += CheckboxCheckedChanged;
        RegisterButton.Clicked += RegisterButtonClicked;
    }

    private void EntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry && PasswordEntry != null)
        {
            //OBTAIN THE WRITTEN INPUT
            ValidateInputs();
        }
    }

    private void CheckboxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        //OBTAIN INPUT FOR CHECKBOX
        ValidateInputs();
    }

    private void RegisterButtonClicked(object sender, EventArgs e)
    {
        //IF INPUT INSERTED CORRECTLY, DISPLAY THIS
        if (RegisterButton.IsEnabled)
        {
            DisplayAlert("Registration", "Registration successful!", "OK");
        }
    }

    private void ValidateInputs()
    {
        //IF ALL INPUT HAVE VAlUES, CHECK CONDITION, NUMBER MUST BE VALID, PASSWORD > 6, AND CHECKBOX TICKED, IF SUCCESS THEN REGISTER BUTTON CLICKABLE
        if (PhoneEntry != null && PasswordEntry != null && TermsAndConditionCheckbox != null)
        {
            bool isPhoneNumberValid = IsPhoneNumberValid(PhoneEntry.Text);
            bool isPasswordLengthValid = PasswordEntry.Text != null && PasswordEntry.Text.Length >= 6;
            bool isTermsChecked = TermsAndConditionCheckbox.IsChecked;

            InvalidPhoneLabel.IsVisible = !isPhoneNumberValid;
            InvalidPasswordLabel.IsVisible = !isPasswordLengthValid;

            RegisterButton.IsEnabled = isPhoneNumberValid && isPasswordLengthValid && isTermsChecked;
        }
    }

    private bool IsPhoneNumberValid(string phoneNumber)
    {
        //IF PHONE NUMBER IS VALID 
        return !string.IsNullOrEmpty(phoneNumber) && System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d+$");
    }
}
