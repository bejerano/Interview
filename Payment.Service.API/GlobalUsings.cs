// Microsoft packages 
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.OData.Query;
global using System.Reflection;

// 3rd party packages
global using AspNetCoreRateLimit;
global using FluentValidation;
global using Microsoft.AspNetCore.OData;
global using MediatR;
global using Microsoft.OpenApi.Models;
global using AutoMapper;
global using Microsoft.Extensions.Diagnostics.HealthChecks;

// Logging packages
global using Serilog;
global using Serilog.Exceptions;
global using Serilog.Sinks.Elasticsearch;

// Custom packages
global using Plooto.Assessment.Payment.API;
global using Plooto.Assessment.Payment.Application;
global using Plooto.Assessment.Payment.Domain.Common;
global using Plooto.Assessment.Payment.Infrastructure.Repositories;
global using Plooto.Assessment.Payment.API.ViewModels;
