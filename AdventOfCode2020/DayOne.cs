using System.Linq;

namespace AdventOfCode2020
{
    public class DayOne
    {
        public static int GetListBiProduct(int[] expenses, int expectedSum)
        {
            return expenses.Select(expense => expense * expenses.Except(new int[] { expense }).FirstOrDefault(expensesB => expensesB + expense == expectedSum))
                .Where(expenseProduct => expenseProduct > 0)
                .FirstOrDefault();
        }

        public static int GetListTriProduct(int[] expenses, int expectedSum)
        {
            return expenses.SelectMany(expense => expenses.Except(new int[] { expense }).Select(expenseB =>
            {
                var finalNumber = expenses.Except(new int[] { expense, expenseB }).FirstOrDefault(expensesC => expense + expenseB + expensesC == expectedSum);
                var finalNumberIsValid = finalNumber > 0;
                return finalNumberIsValid ? expense * expenseB * finalNumber: 0;
            }))
                .Where(expenseProduct => expenseProduct > 0)
                .FirstOrDefault();
        }
    }
}
