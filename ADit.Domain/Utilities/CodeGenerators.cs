using System;

namespace ADit.Domain.Utilities
{
    public static class CodeGenerators
    {

        /// <summary>
        /// Generates the activation code.
        /// </summary>
        /// <returns></returns>
        internal static string GenerateActivationCode()
        {
            return Guid.NewGuid().ToString();
        }



    }
}
