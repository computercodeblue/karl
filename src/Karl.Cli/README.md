# Karl.Cli

Karl includes a standalone CLI tool for:

* Sending test emails
* Rendering templates
* Local development workflows
* CI/CD pipelines
* Administrative scripts

## Installing Karl.Cli

```bash
dotnet tool install --global Karl.Cli
```

Or locally:

```bash
dotnet new tool-manifest
dotnet tool install Karl.Cli
```

## Basic Usage

### Send an Email

```bash
karl send \
  --from noreply@example.com \
  --smtp-host smtp.example.com \
  --to user@example.com \
  --subject "Hello" \
  --body "# Hello World"
```

### CLI Configuration Sources

`Karl.Cli` reads configuration from:

* `--json <path>` when provided explicitly
* Local config files in current directory (first match wins): `.karl`, `karl`, `karl.json`
* User config directory:
  * Windows: `%USERPROFILE%/.karl`
  * Linux/macOS: `$XDG_CONFIG_HOME/karl` or `~/.config/karl`
* Environment variables prefixed with `KARL_`

Use `__` in environment variable names for nested keys, for example:

```bash
KARL_Karl__Smtp__Host=smtp.example.com
KARL_Karl__Smtp__Port=587
KARL_Karl__Smtp__SecurityMode=StartTlsRequired
```

## Send Using a Template

```bash
karl send \
  --from noreply@example.com \
  --smtp-host smtp.example.com \
  --to user@example.com \
  --subject "Welcome {{name}}" \
  --markdown ./welcome.md \
  --model ./model.json
```

## SMTP Send Example

```bash
karl send \
  --from noreply@example.com \
  --to user@example.com \
  --subject "SMTP test" \
  --body "Sent via Karl CLI" \
  --smtp-host smtp.example.com \
  --smtp-port 587 \
  --username username \
  --password password \
  --tls StartTlsRequired
```

## File Output Mode

```bash
karl file \
  --from noreply@example.com \
  --to user@example.com \
  --subject "File output test" \
  --body "This message is written to disk." \
  --output ./mail-output
```

## StdOut Mode

```bash
karl preview \
  --from noreply@example.com \
  --to user@example.com \
  --subject "Preview test" \
  --body "This message is printed to stdout."
```
