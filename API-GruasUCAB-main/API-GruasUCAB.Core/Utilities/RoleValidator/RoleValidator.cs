<<<<<<< HEAD
=======
using System.Collections.Generic;
using System;

>>>>>>> origin/Development
namespace API_GruasUCAB.Core.Utilities.RoleValidator
{
    public static class RoleValidator
    {
        public static bool CanPerformAction(string role, string targetRole)
        {
            if (role == "Administrador")
            {
                return true;
            }

            if (role == "Proveedor" && targetRole == "Conductor")
            {
                return true;
            }

            return false;
        }
    }
}