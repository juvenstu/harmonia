# Harmonia Services Documentation

This document provides an in-depth description of the services that make up the Harmonia project. Each service has a specific role and interacts with other services to fulfill the overall functionality of the system.

## Overview

The Harmonia project is composed of the following primary services:

1. **Platform Service**
2. **Commands Service**

### Platform Service

**Purpose:**  
The Platform Service is responsible for managing the platforms or systems within the company. It serves as the asset register, maintaining detailed records of each platform.

**Responsibilities:**

- **Create, Read, Update, Delete (CRUD) Operations:** Allows users to perform CRUD operations on platform data.
- **Data Storage:** Stores platform data in a persistent storage system.
- **Integration:** Integrates with other services to provide comprehensive data about platforms.

**Key Components:**

- **Database:** Stores platform information.
- **Repository Pattern:** Used to abstract the database operations and provide a cleaner, more maintainable codebase.
- **Data Transfer Objects (DTOs):** Used to transfer data between the service and other components or services.

**Users:**

- Infrastructure team
- Technical support team
- Engineering team
- Accounting team
- Procurement team

### Commands Service

**Purpose:**  
The Commands Service acts as a repository for command line arguments associated with different platforms. It helps automate support processes by storing and managing these commands.

**Responsibilities:**

- **CRUD Operations:** Allows users to perform CRUD operations on command data for a given platform.
- **Data Storage:** Stores command information in a persistent storage system.
- **Event Processing:** Listens to events from the Platform Service and updates command data accordingly.

**Key Components:**

- **Database:** Stores command information.
- **Repository Pattern:** Abstracts the database operations for command data.
- **Event Bus:** Used to process events from other services (e.g., new platform added).
- **Background Service:** Handles background tasks such as listening for new messages from the message bus.

**Users:**

- Technical support team
- Infrastructure team
- Engineering team

### Common Patterns and Practices

**Repository Pattern:**
Both services use the repository pattern to separate the logic that retrieves data from the business logic. This pattern helps in keeping the code clean and maintainable.

**Data Transfer Objects (DTOs):**
DTOs are used to encapsulate data and send it across different layers of the application. They help in reducing the number of remote calls and make the data transfer more efficient.

**Message Bus (RabbitMQ):**
RabbitMQ is used for asynchronous communication between the services. This allows the system to be more resilient and scalable by decoupling the services.

**gRPC:**
gRPC is used for synchronous communication between services when immediate feedback is required. It provides high performance and reliability.

**Database Migrations:**
Database migrations are used to keep the database schema in sync with the model definitions in the codebase. This ensures that the database structure evolves as the application grows.

## Future Services

As the Harmonia project evolves, additional services may be introduced to enhance functionality, improve performance, or add new features. Each new service will be documented here with a detailed description of its purpose, responsibilities, key components, and users.
