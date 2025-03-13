using SimpleCalculator;

namespace SimpleCalculator;


public partial class MainPage : ContentPage
{
	int currentState = 1;
	string operatorMath;
	double firstNum, secondNum;

	public MainPage()
	{
		InitializeComponent();
		OnClear(this, null);
	}

	void OnClear(object sender, EventArgs e) 
	{ 
		firstNum = 0;
		secondNum = 0;
		currentState = 1;
		this.Result.Text = "0";
	}

	void OnDelete(object sender,EventArgs e)
	{
		this.Result.Text = this.Result.Text.Substring(0, this.Result.Text.Length - 1);
	}

	void OnNumberSelection(object sender,EventArgs e)
	{
		Button button = (Button)sender;
		string btnPressed = button.Text;

		if(this.Result.Text == "0" || currentState < 0)
		{
			this.Result.Text = string.Empty;
			if(currentState < 0)
				currentState *= -1;
		}

		this.Result.Text += btnPressed;

		double number;
		if(double.TryParse(this.Result.Text,out number))
		{
			this.Result.Text = number.ToString("N0");
			if(currentState == 1)
			{
				firstNum = number;
			}
			else
			{
				secondNum = number;
			}
		}
	}


	void OnOperatorSelection(object sender ,EventArgs e)
	{
		currentState = -2;
		Button button= (Button)sender;
		string btnPressed = button.Text;
		operatorMath = btnPressed;
	}

	void OnCalculate(object sender,EventArgs e)
	{
		if(currentState == 2)
		{
			var result = Calculate.DoCalculation(firstNum, secondNum, operatorMath);

			this.Result.Text = result.ToString();
			firstNum = result;
			currentState = -1;
		}
	}


}
