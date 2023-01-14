using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionHomeWork
{
    public class MathExpressionSolver
    {
        public string Expression { get; }
        public MathExpressionSolver(string expression)
        {
            Expression = expression;
        }
        public string GetMethodName()
        {
            int index = Expression.IndexOf('(');
            if (index != -1)
            {
                return Expression.Substring(0, index);
            }
            else
                throw new ArgumentException("Invalid foramt");
        }

        public object[] GetArguments()
        {
            int firstIndex = Expression.IndexOf('(');
            int secondeIndex = Expression.IndexOf(')');

            
            if (firstIndex == -1 || secondeIndex == -1)
                throw new ArgumentException("Invalid format");

            string arguments = Expression.Substring(firstIndex + 1, secondeIndex - firstIndex - 1);
            string[] argumetsArrayInString;

            if (arguments.Contains(","))
            {
                argumetsArrayInString = arguments.Split(',');
            }
            else
            {
                argumetsArrayInString = new string[] { arguments };
            }
            object[] argumentsArray = new object[argumetsArrayInString.Length];
            for (int i = 0; i < argumetsArrayInString.Length; i++)
            {
                argumentsArray[i] = Convert.ToDouble(argumetsArrayInString[i]);
            }
            return argumentsArray;
        }
        public double Calculate()
        {
            string methodName = GetMethodName();
            object[] arguments = GetArguments();
            Type t = typeof(Math);
            MethodInfo[] methods = t.GetMethods();
            MethodInfo memberInfo = null;
            foreach (var item in methods)
            {
                if (item.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase) && arguments.Count() == item.GetParameters().Count())
                {
                    memberInfo = item;
                    break;
                }
            }
            if (memberInfo == null)
            {
                throw new ArgumentException("Method not found");
            }

            double result = (double)memberInfo.Invoke(null, arguments);
            return result;
        }
    }
}
