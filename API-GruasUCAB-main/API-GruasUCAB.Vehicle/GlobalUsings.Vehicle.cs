﻿global using API_GruasUCAB.Core.Application.Services;
global using API_GruasUCAB.Core.Infrastructure.EventStore;
global using API_GruasUCAB.Core.Domain.DomainException;
global using API_GruasUCAB.Core.Domain.AggregateRoot;
global using API_GruasUCAB.Core.Domain.ValueObject;
global using API_GruasUCAB.Core.Domain.DomainEvent;
global using API_GruasUCAB.Core.Domain.Entity;
global using API_GruasUCAB.Core.Domain.conf;
global using API_GruasUCAB.Commons.Exceptions;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.AspNetCore.Http;
global using System.Threading.Tasks;
global using System.Threading;
global using System;
global using MediatR;
global using API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository;
global using API_GruasUCAB.Auth.Infrastructure.Adapters.HeadersToken;
global using API_GruasUCAB.Supplier.Domain.ValueObject;
global using API_GruasUCAB.Users.Domain.ValueObject;