﻿using System.Net.Http.Json;
using System.Text.Json;
using dominikz.shared.Contracts;
using Microsoft.AspNetCore.Components;

namespace dominikz.dev.Endpoints;

public class ApiClient
{
    private readonly HttpClient _client;
    
    public const string Prefix = "api";

    private readonly JsonSerializerOptions _serializerOptions;

    public ApiClient(HttpClient client)
    {
        _client = client;
        _serializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, };
    }

    public async Task<T?> Get<T>(string endpoint, Guid id, CancellationToken cancellationToken) where T : new()
        => await _client.GetFromJsonAsync<T>($"{Prefix}/{endpoint}/{id}", _serializerOptions, cancellationToken);

    public async Task<List<T>> Get<T>(string endpoint, CancellationToken cancellationToken) where T : new()
        => await Get<T>(endpoint, null, cancellationToken);

    public async Task<List<T>> Get<T>(string endpoint, IFilter? filter, CancellationToken cancellationToken) where T : new()
    {
        var route = CreateEndpointUrl(endpoint, filter);
        var result = await _client.GetFromJsonAsync<List<T>>(route, _serializerOptions, cancellationToken);
        return result ?? new List<T>();
    }

    public string Curl(string endpoint, IFilter? filter)
    {
        var route = CreateEndpointUrl(endpoint, filter);
        return $"curl {_client.BaseAddress}{route}";
    }

    private static string CreateEndpointUrl(string endpoint, IFilter? filter)
    {
        var route = $"{Prefix}/{endpoint}";

        var parameter = filter?.GetParameter()
            .Select(x => $"{x.Name}={x.Value}")
            .ToList() ?? new List<string>();

        if (parameter.Count > 0)
        {
            var query = string.Join('&', parameter);
            route += $"?{query}";
        }

        return route;
    }
}
