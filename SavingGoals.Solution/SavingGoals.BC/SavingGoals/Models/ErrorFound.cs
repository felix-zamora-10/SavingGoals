using System.Collections.Generic;

namespace SavingGoals.BC.SavingGoals.Models {
    public class ErrorFound {

        public bool IsThereAnyError { get; set; }

        public List<string> ErrorsFound { get; set; }
    }
}
