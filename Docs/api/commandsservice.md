# Commands Service API

## Endpoints

### `GET /api/commands`

Retrieves all commands.

#### Response

- `200 OK`: Returns a list of commands.

### `GET /api/commands/{id}`

Retrieves a specific command by ID.

#### Parameters

- `id` (int): The ID of the command.

#### Response

- `200 OK`: Returns the command.
- `404 Not Found`: If the command does not exist.

### `POST /api/commands`

Creates a new command.

#### Request Body

- `platformId` (int): The ID of the platform.
- `commandLine` (string): The command line.

#### Response

- `201 Created`: If the command was successfully created.
- `400 Bad Request`: If the request is invalid.
