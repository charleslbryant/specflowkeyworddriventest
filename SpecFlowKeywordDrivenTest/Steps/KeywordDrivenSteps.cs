namespace SpecFlowKeywordDriventTest.Demo.Steps
{
	using System;
	using NUnit.Framework;
	using OpenQA.Selenium;
	using OpenQA.Selenium.IE;
	using TechTalk.SpecFlow;
	using SpecFlowKeywordDriventTest.Demo.Core;
	using SpecFlowKeywordDriventTest.Demo.Pages;

	[Binding]
	public class KeywordDrivenSteps
	{
		private IWebDriver driver;
		private BaseKeywordDrivenPage testPage;

		[Given(@"I am on the ""(.*)"" page")]
		public void GivenIAmOnThePage(string pageName)
		{
			this.SetPage(pageName);
			this.testPage.Open();
		}

		[Given(@"I enter ""(.*)"" in ""(.*)""")]
		public void GivenIEnterTextIn(string text, string controlName)
		{
			this.testPage.EnterText(controlName, text);
		}

		[BeforeScenario]
		public void SetupScenario()
		{
			Proxy proxy = new Proxy();

			//proxy.IsAutoDetect = true;
			proxy.Kind = ProxyKind.Manual;

			var options = new OpenQA.Selenium.IE.InternetExplorerOptions
			{
				EnsureCleanSession = true,
				Proxy = proxy,
				UsePerProcessProxy = true
			};

			this.driver = new OpenQA.Selenium.IE.InternetExplorerDriver(options);
		}

		[AfterScenario]
		public void TearDownScenario()
		{
			this.driver.Quit();
		}

		[Then(@"I should be on the ""(.*)"" page")]
		public void ThenIShouldBeOnThePage(string pageName)
		{
			this.SetPage(pageName);
			Assert.IsTrue(this.testPage.IsOpen());
		}

		[Then(@"""(.*)"" text should be ""(.*)""")]
		public void ThenTheElementShouldHaveText(string controlName, string text)
		{
			Assert.IsTrue(this.testPage.HasText(controlName, text));
		}

		[When(@"I click ""(.*)""")]
		public void WhenIClick(string controlName)
		{
			this.testPage.Click(controlName);
		}

		//Instantiate page object from string;
		//Bad because we have to keep adding pages to the if or switch statement when we have a new page
		//We could use some reflection magic and enforce naming conventions
		private void SetPage(string page)
		{
			switch (page)
			{
				case "Welcome":
					{
						this.testPage = new WelcomePage(driver);
						return;
					}
				case "Success":
					{
						this.testPage = new SuccessPage(driver);
						return;
					}
			}

			throw new ApplicationException("Invalid page.");
		}
	}
}