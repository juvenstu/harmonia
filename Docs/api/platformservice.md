# Platform Service API

## Endpoints

### `GET /api/platforms`

Retrieves all platforms.

#### Response

- `200 OK`: Returns a list of platforms.

### `GET /api/platforms/{id}`

Retrieves a specific platform by ID.

#### Parameters

- `id` (int): The ID of the platform.

#### Response

- `200 OK`: Returns the platform.
- `404 Not Found`: If the platform does not exist.

### `POST /api/platforms`

Creates a new platform.

#### Request Body

- `name` (string): The name of the platform.
- `publisher` (string): The publisher of the platform.
- `cost` (string): The cost of the platform.

#### Response

- `201 Created`: If the platform was successfully created.
- `400 Bad Request`: If the request is invalid.
