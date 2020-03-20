using System;

namespace SavingGoals.BC.Utilities {
    [Serializable()]
    public class SavingGoalException : Exception {

        public SavingGoalException() : base() { }

        public SavingGoalException(string message) : base(message) { }

        public SavingGoalException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected SavingGoalException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
