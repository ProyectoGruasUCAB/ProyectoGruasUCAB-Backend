﻿global using API_GruasUCAB.Core.Domain.ValueObject;
global using API_GruasUCAB.Core.Domain.AggregateRoot;
global using API_GruasUCAB.Core.Domain.DomainEvent;
global using API_GruasUCAB.Core.Application.Services;
global using API_GruasUCAB.Commons.Exceptions;
global using API_GruasUCAB.Common.Calculate;
global using System.Threading.Tasks;
global using System.Threading;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using MediatR;
global using System;
global using API_GruasUCAB.Core.Domain.conf;
global using API_GruasUCAB.Auth.Infrastructure.Adapters.KeycloakRepository;
global using API_GruasUCAB.Auth.Infrastructure.Adapters.HeadersToken;
global using Microsoft.AspNetCore.Http;