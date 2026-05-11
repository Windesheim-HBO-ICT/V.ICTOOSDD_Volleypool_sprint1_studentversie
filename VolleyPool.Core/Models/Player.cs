using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace VolleyPool.Core.Models
{
    public class Player
    {
        public int MemberId;
        public string Name;
        public string? Surname; //sprint-3-uc1-invoeren-speler
        public DateTime BirthDate;
        public string? ParentOneId;
        public string? ParentTwoId;
        public int[] CancellationIds = [];

        // For the sake of simplicity, the fields of the Player class have been implemented as public fields instead of properties.
        // This is considered bad practice in C#. When fields are public, the class loses control over how values are validated, accessed,
        // or modified. This breaks encapsulation, one of the core principles of object-oriented design.

        public override string ToString()
        {
            return $"{MemberId} {Name} {BirthDate}, parentOneId: {ParentOneId}, parentTwoId: {ParentTwoId}"; // Example of string interpolation.
        }
    }
}
