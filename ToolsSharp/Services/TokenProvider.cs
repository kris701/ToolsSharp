using Microsoft.Identity.Client;
using Microsoft.Kiota.Abstractions.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolsSharp.Services
{
	// https://medium.com/@mitchelldalehein25/connecting-to-microsoft-graph-api-with-a-client-secret-c-f791440231f1
	internal class TokenProvider : IAccessTokenProvider
	{
		private readonly string _clientId;
		private readonly string _clientSecret;
		private readonly string _tenantId;
		public TokenProvider(string clientId, string clientSecret, string tenantId)
		{
			_clientId = clientId;
			_clientSecret = clientSecret;
			_tenantId = tenantId;
		}
		public Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object> additionalAuthenticationContext = default,
			CancellationToken cancellationToken = default)
		{
			var app = ConfidentialClientApplicationBuilder.Create(_clientId)
				.WithClientSecret(_clientSecret)
				.WithAuthority(new Uri($"https://login.microsoftonline.com/{_tenantId}"))
				.Build();
			var scopes = new string[] { "https://graph.microsoft.com/.default" };
			var result = app.AcquireTokenForClient(scopes).ExecuteAsync().Result;
			return Task.FromResult(result.AccessToken);
		}
		public AllowedHostsValidator AllowedHostsValidator { get; }
	}
}
