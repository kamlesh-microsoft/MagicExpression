namespace MagicExpression.Test
{
	using System;
	using System.Text.RegularExpressions;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	public abstract class MagicTest
	{
		protected MagicTest()
		{
		}

		protected IMagex Magic { get; set; }

		protected void AssertIsMatching(params string[] strings)
		{
			Regex expression = new Regex(this.Magic.Expression);

			foreach (string shouldMatch in strings)
			{
				string message = String.Format("Expression: {0} should match: {1}", this.Magic.Expression, shouldMatch);

				Assert.IsTrue(expression.IsMatch(shouldMatch), message);
			}
		}

		protected void AssertIsNotMatching(params string[] strings)
		{
			Regex expression = new Regex(this.Magic.Expression);

			foreach (string shouldMatch in strings)
			{
				string message = String.Format("Expression: {0} should not match: {1}", this.Magic.Expression, shouldMatch);

				Assert.IsFalse(expression.IsMatch(shouldMatch), message);
			}
		}

		protected void AssertCaptures(Func<MatchCollection, bool> assertion, params string[] strings)
		{
			Regex expression = new Regex(this.Magic.Expression);

			foreach (string candidate in strings)
			{
				string message = String.Format("String {0} captures should respect assertion", candidate);

				Assert.IsTrue(assertion(expression.Matches(candidate)), message);
			}
		}

		public virtual void Setup()
		{
			this.Magic = Magex.New();
		}
	}
}
