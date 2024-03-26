using System;
using System.Linq.Expressions;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var employees = new List<Employee> {
            new Employee {
                Name = "gary",
                HireDate = new DateTime(2017, 1, 1)
            },
            new Employee {
                Name = "spencer",
                HireDate = new DateTime(2014, 12, 31)
            },
            new Employee {
                Name = "michael",
                HireDate = new DateTime(2017, 1, 1)
            },
            new Employee {
                Name = "amy",
                HireDate = new DateTime(2017, 1, 1)
            },
        };

        foreach (var emp in employees.AsQueryable().OrderByPropertyOrField("Name"))
        {
            Console.WriteLine("{0} - {1:d}", emp.Name, emp.HireDate);
        }
    }
}

public class Employee
{
    public string Name { get; set; }
    public DateTime HireDate { get; set; }
}

public static class EnumerableExtensions
{
    //ripped shamelessly from https://github.com/schneidenbach/AspNetPagingExample

    /// <summary>
    /// Order the IQueryable by the given property or field.
    /// </summary>
    /// <typeparam name="T">The type of the IQueryable being ordered.</typeparam>
    /// <param name="queryable">The IQueryable being ordered.</param>
    /// <param name="propertyOrFieldName">The name of the property or field to order by.</param>
    /// <param name="ascending"></param>
    /// <returns>Returns an IQueryable ordered by the specified field.</returns>
    public static IQueryable<T> OrderByPropertyOrField<T>(this IQueryable<T> queryable, string propertyOrFieldName, bool ascending = true)
    {
        var elementType = typeof(T);
        var orderByMethodName = ascending ? "OrderBy" : "OrderByDescending";

        var parameterExpression = Expression.Parameter(elementType);
        var propertyOrFieldExpression = Expression.PropertyOrField(parameterExpression, propertyOrFieldName);
        var selector = Expression.Lambda(propertyOrFieldExpression, parameterExpression);

        var orderByExpression = Expression.Call(typeof(Queryable), orderByMethodName,
                                                new[] { elementType, propertyOrFieldExpression.Type }, queryable.Expression, selector);

        var returnInstance = queryable.Provider.CreateQuery<T>(orderByExpression);
        return returnInstance;
    }
}