using SavingGoals.BC.SavingCalculation.Models;
using SavingGoals.BC.SavingGoals.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SavingGoals.BC.SavingCalculation {
    public class SavingCalculator {

        private const int LAST_MONTH = 12;

        public decimal GetTotalAmount(SavingGoal savingGoal) {
            decimal totalAmount = savingGoal.InitialAmount;

            foreach (MonthlyMovement monthlyMovement in savingGoal.MonthlyMovements) {
                totalAmount += monthlyMovement.SavedAmount;
            }

            return totalAmount;
        }

        public List<Period> CreateCurrentAndFutureTransactions(List<MonthlyMovement> monthlyMovements, decimal totalAmount, 
                                                               decimal estimatedAmount, decimal savingPerMonth) {
            List<Period> currentAndFutureTransactions = new List<Period>();
            Period lastPeriod;
            decimal remainingAmount;
            int periods;

            lastPeriod = GetLastPeriod(monthlyMovements);
            remainingAmount = GetRemainingAmount(totalAmount, estimatedAmount);
            periods = GetPeriods(remainingAmount, savingPerMonth);

            currentAndFutureTransactions.AddRange(GetTransactionsMade(monthlyMovements));
            currentAndFutureTransactions.AddRange(GetRemainingPeriods(periods, lastPeriod, totalAmount, savingPerMonth));

            return currentAndFutureTransactions;
        }

        private Period GetLastPeriod(List<MonthlyMovement> monthlyMovements) {
            Period period;

            monthlyMovements = monthlyMovements.OrderByDescending(movement => movement.Year).ThenBy(movement => movement.Month).ToList();
            period = new Period {
                Year = monthlyMovements[0].Year,
                Month = monthlyMovements[0].Month
            };

            return period;
        }

        private List<Period> GetTransactionsMade(List<MonthlyMovement> monthlyMovements) {
            List<Period> transactionsMade = new List<Period>();

            foreach (MonthlyMovement monthlyMovement in monthlyMovements) {
                transactionsMade.Add(new Period {
                    Year = monthlyMovement.Year,
                    Month = monthlyMovement.Month,
                    SavedAmount = monthlyMovement.SavedAmount
                });
            }

            return transactionsMade;
        }

        private decimal GetRemainingAmount(decimal totalAmount, decimal estimatedAmount) {
            decimal remainingAmount;

            remainingAmount = estimatedAmount - totalAmount;

            return remainingAmount;
        }

        private int GetPeriods(decimal remainingAmount, decimal savingPerMonth) {
            decimal periods;
            int periodsConverted;

            periods = Math.Ceiling(remainingAmount / savingPerMonth);
            periodsConverted = decimal.ToInt32(periods);

            return periodsConverted;
        }

        private List<Period> GetRemainingPeriods(int periods, Period lastPeriod, decimal totalAmount, 
                                                decimal savingPerMonth) {
            List<Period> remainingPeriods = new List<Period>();

            if(lastPeriod.Month != LAST_MONTH) {
                remainingPeriods.AddRange(CompleteCurrentYear(lastPeriod, totalAmount, savingPerMonth));

                int periodsCovered = LAST_MONTH - lastPeriod.Month;
                totalAmount = remainingPeriods[remainingPeriods.Count - 1].SavedAmount;
                periods -= periodsCovered;
                lastPeriod.Year += 1;
                lastPeriod.Month = LAST_MONTH;
            }

            remainingPeriods.AddRange(CompletePeriods(periods, lastPeriod, totalAmount, savingPerMonth));

            return remainingPeriods;
        }

        private List<Period> CompleteCurrentYear(Period lastPeriod, decimal totalAmount, decimal savingPerMonth) {
            List<Period> remainingPeriods = new List<Period>();

            for (int currentMonth = lastPeriod.Month + 1; currentMonth <= LAST_MONTH; currentMonth ++) {
                totalAmount += savingPerMonth;

                remainingPeriods.Add(new Period {
                    Year = lastPeriod.Year,
                    Month = currentMonth,
                    SavedAmount = totalAmount
                });
            }

            return remainingPeriods;
        }

        private List<Period> CompletePeriods(int periods, Period lastPeriod, decimal totalAmount, decimal savingPerMonth) {
            List<Period> remainingPeriods = new List<Period>();

            for (int currentYear = lastPeriod.Year + 1; periods == 0; currentYear ++) {
                for (int currentMonth = 1; currentMonth <= 12; currentMonth ++) {
                    totalAmount += savingPerMonth;

                    remainingPeriods.Add(new Period {
                        Year = currentYear,
                        Month = currentMonth,
                        SavedAmount = totalAmount
                    });

                    periods--;
                    if (periods == 0) break;
                }
            }

            return remainingPeriods;
        }
    }
}
