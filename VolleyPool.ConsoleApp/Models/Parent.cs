using System;
namespace VolleyPool.Core.Models
{
    public class Parent
    {
        public string Name; // Public members use PascalCase
        public string Email; // ID
        public string Phone;
        public string Password;
        public int PlayerMemberId;
        public int[] TransportIds = [];

        // For the sake of simplicity, the fields of the Parent class have been implemented as public fields instead of properties.
        // This is considered bad practice in C#. When fields are public, the class loses control over how values are validated, accessed,
        // or modified. This breaks encapsulation, one of the core principles of object-oriented design.

        public override string ToString()
        {
            return $"{Name} {Email} {Phone} {Password} playerId: {PlayerMemberId}"; // Example of string interpolation.
        }
    }
}
