# pd-study-apis

Learning project: consuming third-party REST APIs in C#.

## TrelloExplorer

A .NET 8 console app that authenticates to the [Trello API](https://developer.atlassian.com/cloud/trello/rest/)
and prints my boards, their lists, and the cards on them — using `HttpClient`, typed
`record` models, and `System.Text.Json`. No frameworks, no database.

**Goal for week 1 (Sep 1–6, 2026):** running the app prints a real board → lists → cards
tree, with explicit handling for bad tokens and bad ids.

### Running it

```bash
cd TrelloExplorer
dotnet run
```

Credentials are stored with `dotnet user-secrets` and are never committed:

```bash
dotnet user-secrets set "Trello:ApiKey" "<key>"
dotnet user-secrets set "Trello:Token" "<token>"
```

### Notes

- Pinned to the .NET 8 LTS SDK via `global.json`.
