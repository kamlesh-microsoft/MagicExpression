namespace MagicExpression.Elements
{

	public class NonCapturingGroup : CapturingGroup
	{
		public NonCapturingGroup(IExpressionElement grouped)
			: base(grouped)
		{
		}

		public override string Expression
		{
			get
			{
				return "(?:" + this.Grouped.Expression + ")";
			}
		}
	}
}
