using System.Collections.Generic;

namespace SavingGoals.BC.SavingGoals.Models {
    public class ErrorFound {

        public ErrorFound() {
            ErrorsFound = new List<string>();
        }

        public bool IsThereAnyError { get; set; }

        public List<string> ErrorsFound { get; set; }
    }
}
