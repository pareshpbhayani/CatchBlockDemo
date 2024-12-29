// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;

ParameterExpression ex = Expression.Parameter(typeof(Exception), "ex");

// Body of the try block
Expression tryBody = Expression.Throw(
    Expression.Constant(new InvalidOperationException("An error occurred!")));

// Catch block that handles the exception
CatchBlock catchBlock = Expression.Catch(
    ex,
    Expression.Call(
        typeof(Console).GetMethod("WriteLine", new[] { typeof(string) }),
        Expression.Constant("Exception caught!")
    )
);

// Try-Catch Expression
Expression tryCatchExpression = Expression.TryCatch(tryBody, catchBlock);

// Compile and execute
Action action = Expression.Lambda<Action>(tryCatchExpression).Compile();
action();