# Harmonia API Documentation

Welcome to the Harmonia API documentation. This section provides an overview of the API structure and the purpose of each service.

## Overview

The Harmonia project consists of two main services:

1. **Platform Service**
   - Function: Asset Register
   - Purpose: Tracks all the platforms/systems in the company
   - Used by: Infrastructure team, technical support team, engineering, accounting, procurement

2. **Commands Service**
   - Function: Repository for command line arguments for a given platform
   - Purpose: Aids in the automation of support processes
   - Used by: Technical support team, infrastructure team, engineering

## API Endpoints

Each service exposes its own set of API endpoints. Detailed documentation for each endpoint can be found in the respective service documentation.

### Platform Service Endpoints

- `/api/platforms` - Retrieve, create, update, and delete platform information.
- `/api/platforms/{id}` - Retrieve detailed information about a specific platform.

### Commands Service Endpoints

- `/api/platforms/{platformId}/commands` - Retrieve, create, update, and delete command information for a specific platform.
- `/api/platforms/{platformId}/commands/{commandId}` - Retrieve detailed information about a specific command.

For detailed usage, request and response formats, refer to the specific service documentation:

- [Platform Service API Documentation](platformservice.md)
- [Commands Service API Documentation](commandsservice.md)

## Getting Started

To start using the Harmonia API, follow the instructions in the [Installation Guide](../installation.md).

## Contact

For any questions or issues, please contact the project maintainers.

---

[Back to Main Documentation](../index.md)
