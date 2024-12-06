using System.Collections.Generic;
using System;

namespace API_GruasUCAB.Core.Infrastructure.RoleValidator
{
    public class RoleValidator
    {
        private readonly Dictionary<string, List<string>> _rolePermissions;

        public RoleValidator()
        {
            _rolePermissions = new Dictionary<string, List<string>>
            {
                { "Administrador", new List<string> { "Create", "Delete", "CreateAny", "DeleteAny" } },
                { "Proveedor", new List<string> { "CreateConductor", "DeleteConductor" } },
                { "Trabajador", new List<string> { } },
                { "Conductor", new List<string> { } }
            };
        }

        public void ValidateCreateUser(string role, string targetRole)
        {
            if (role == "Administrador")
            {
                return;
            }

            if (role == "Proveedor" && targetRole == "Conductor")
            {
                return;
            }

            throw new UnauthorizedAccessException("No tiene permisos para crear este tipo de usuario.");
        }

        public void ValidateDeleteUser(string role, string targetRole)
        {
            if (role == "Administrador")
            {
                return;
            }

            if (role == "Proveedor" && targetRole == "Conductor")
            {
                return;
            }

            throw new UnauthorizedAccessException("No tiene permisos para eliminar este tipo de usuario.");
        }
    }
}