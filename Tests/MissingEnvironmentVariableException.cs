using System;

namespace Sms77Api.Tests {
    [Serializable()]
    public class MissingEnvironmentVariableException : Exception {
        public MissingEnvironmentVariableException() {
        }

        public MissingEnvironmentVariableException(string message) : base(message) {
        }

        public MissingEnvironmentVariableException(string message, Exception inner) : base(message, inner) {
        }

        // Cnstructor needed for serialization when an exception propagates from a remoting server to the client.
        protected MissingEnvironmentVariableException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) {
        }
    }
}