global using API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository;
global using API_GruasUCAB.Auth.Application.Decorators;
global using API_GruasUCAB.Core.Application.Services;
global using API_GruasUCAB.Core.Domain.DomainException;
global using API_GruasUCAB.Core.Domain.AggregateRoot;
global using API_GruasUCAB.Core.Domain.ValueObject;
global using API_GruasUCAB.Core.Domain.DomainEvent;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.AspNetCore.Http;
global using System.Threading.Tasks;
global using System.Globalization;
global using System.Threading;
global using System;
global using MediatR;
global using API_GruasUCAB.ServiceOrder.Infrastructure.Repositories;
global using API_GruasUCAB.ServiceFee.Domain.ValueObject;
global using API_GruasUCAB.Policy.Domain.ValueObject;
global using API_GruasUCAB.Users.Domain.ValueObject;
global using API_GruasUCAB.Vehicle.Domain.ValueObject;
global using Microsoft.Extensions.Configuration;
global using Microsoft.EntityFrameworkCore;
global using API_GruasUCAB.ServiceOrder.Infrastructure.Database;
global using API_GruasUCAB.ServiceOrder.Infrastructure.Mappers;
global using API_GruasUCAB.Users.Infrastructure.Database;
global using AutoMapper;