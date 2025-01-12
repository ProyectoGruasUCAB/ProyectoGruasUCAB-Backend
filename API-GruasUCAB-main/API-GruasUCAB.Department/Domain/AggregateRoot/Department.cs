using API_GruasUCAB.Department.Domain.ValueObject;
using API_GruasUCAB.Department.Domain.Events;
using API_GruasUCAB.Core.Domain.AggregateRoot;
using System;
using System.Collections.Generic;

namespace API_GruasUCAB.Department.Domain.AggregateRoot
{
     public class Department : AggregateRoot<DepartmentId>
     {
          public DepartmentName Name { get; private set; }
          public DepartmentDescription Description { get; private set; }

          public Department(DepartmentId id, DepartmentName name, DepartmentDescription description)
              : base(id)
          {
               Name = name ?? throw new ArgumentNullException(nameof(name), "Department must have a name.");
               Description = description ?? throw new ArgumentNullException(nameof(description), "Department must have a description.");

               ValidateState();
               AddDomainEvent(new DepartmentCreatedEvent(id, name, description));
          }

          protected override void ValidateState()
          {
               ValidateName();
               ValidateDescription();
          }

          private void ValidateName()
          {
               if (Name == null)
                    throw new InvalidDepartmentNameException();
          }

          private void ValidateDescription()
          {
               if (Description == null)
                    throw new InvalidDepartmentDescriptionException();
          }

          public void ChangeName(DepartmentName newName)
          {
               if (newName == null)
                    throw new ArgumentNullException(nameof(newName), "New name cannot be null.");
               Name = newName;
               ValidateState();
               AddDomainEvent(new DepartmentNameChangedEvent(Id, newName));
          }

          public void ChangeDescription(DepartmentDescription newDescription)
          {
               if (newDescription == null)
                    throw new ArgumentNullException(nameof(newDescription), "New description cannot be null.");
               Description = newDescription;
               ValidateState();
               AddDomainEvent(new DepartmentDescriptionChangedEvent(Id, newDescription));
          }
     }
}