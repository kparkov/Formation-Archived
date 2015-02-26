using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bit.Helpers.Reflection
{
	public class ExpressionTools
	{
		public static string GetFullMemberName(Expression body)
		{
			var memberExpression = GetMemberExpression(body);

			var parts = new List<string>();

			Expression m = memberExpression;

			while (m is MemberExpression)
			{
				parts.Add((m as MemberExpression).Member.Name);
				m = (m as MemberExpression).Expression;
			}

			parts.Reverse();

			return String.Join(".", parts);
		}


		public static MemberExpression GetMemberExpression(Expression body)
		{
			return GetMemberExpressions(body).FirstOrDefault();
		}

		public static List<MemberExpression> GetMemberExpressions(Expression body)
		{
			var results = new List<MemberExpression>();

			var candidates = new Queue<Expression>();
			candidates.Enqueue(body);
			while (candidates.Count > 0)
			{
				var expr = candidates.Dequeue();

				if (expr is MemberExpression)
				{
					results.Add((MemberExpression)expr);
				}
				else if (expr is UnaryExpression)
				{
					candidates.Enqueue(((UnaryExpression)expr).Operand);
				}
				else if (expr is BinaryExpression)
				{
					var binary = expr as BinaryExpression;
					candidates.Enqueue(binary.Left);
					candidates.Enqueue(binary.Right);
				}
				else if (expr is MethodCallExpression)
				{
					var method = expr as MethodCallExpression;
					foreach (var argument in method.Arguments)
					{
						candidates.Enqueue(argument);
					}
				}
				else if (expr is LambdaExpression)
				{
					candidates.Enqueue(((LambdaExpression)expr).Body);
				}
			}

			return results;
		}
	}
}
