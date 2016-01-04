using System;

namespace Repository.Enums
{
    public enum UserRole
    {
        None = 1,
        CurrentMember = 2,
        FormerMember = 4,
        ScientificSupervisor = 8,
        Partner = 16
    }
}